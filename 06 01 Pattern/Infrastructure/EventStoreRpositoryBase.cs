namespace _06_01_Pattern.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    public class EventStoreRpositoryBase<T> where T : Aggregate
    {
        protected IEventStoreConnection connection;

        public EventStoreRpositoryBase()
        {
            connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.Connect();
        }

        protected string GetStreamName(Guid aggregateId)
        {
            return string.Format("{0}-{1}", typeof(T).Name, aggregateId);
        }

        /// <summary>
        /// Serialize @event object to JSON and converts to byte array, builds metadata for event and builds EventData object.
        /// </summary>
        protected EventData DomainEventToEventData(Guid eventId, object @event, IDictionary<string, object> headers = null)
        {
            if (headers == null) headers = new Dictionary<string, object>();
            var serializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None };

            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, serializerSettings));

            var eventHeaders = new Dictionary<string, object>(headers)
                {
                    {
                        "EventClrTypeName", @event.GetType().AssemblyQualifiedName
                    }
                };
            var metadata = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(eventHeaders, serializerSettings));
            var typeName = @event.GetType().Name;

            return new EventData(eventId, typeName, true, data, metadata);
        }

        /// <summary>
        /// Reads all events in stream
        /// </summary>
        protected IEnumerable<ResolvedEvent> ReadAllEventsInStream(string streamName, IEventStoreConnection connection, int pageSize = 500)
        {
            var result = new List<ResolvedEvent>();
            var coursor = StreamPosition.Start;
            StreamEventsSlice events = null;
            do
            {
                events = connection.ReadStreamEventsForward(streamName, coursor, pageSize, false);
                result.AddRange(events.Events);
                coursor = events.NextEventNumber;

            } while (events != null && !events.IsEndOfStream);

            return result;
        }

        /// <summary>
        /// Conversts ResolvedEvent pulled from the stream to domain event.
        /// </summary>
        protected object ResolvedEventToDomainEvent(ResolvedEvent @event)
        {
            var metadataJSON = Encoding.UTF8.GetString(@event.Event.Metadata);
            var metadata = JsonConvert.DeserializeObject<Dictionary<string, object>>(metadataJSON);
            var eventDataJSON = Encoding.UTF8.GetString(@event.Event.Data);

            var eventType =
                Assembly.GetExecutingAssembly().GetTypes().Single(x => x.AssemblyQualifiedName == metadata["EventClrTypeName"].ToString());

            return JsonConvert.DeserializeObject(eventDataJSON, eventType);
        }
    }
}
