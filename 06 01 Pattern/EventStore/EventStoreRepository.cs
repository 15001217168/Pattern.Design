namespace _06_01_Pattern.EventStore
{
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class EventStoreRepository<T> : EventStoreRpositoryBase<T> where T : Aggregate
    {
        public T Get(Guid aggregateId)
        {
            var events = ReadAllEventsInStream(GetStreamName(aggregateId), connection);

            var aggregate = (T)Activator.CreateInstance(typeof(T));

            foreach (var @event in events)
            {
                var appEvent = (Event<T>)ResolvedEventToDomainEvent(@event);
                ApplyEventToAggragate(appEvent, aggregate);
            }

            return aggregate;
        }

        private void ApplyEventToAggragate(Event<T> @event, T aggregate)
        {
            var handleMethods = typeof(T).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "Handle");

            var method = handleMethods.Single(x => x.GetParameters().First().ParameterType.FullName == @event.GetType().FullName);

            method.Invoke(aggregate, new object[] { @event });
        }

        public void SaveEvent(Event<T> @event)
        {
            var streamName = GetStreamName(@event.AggregateID);
            var metadata = new Dictionary<string, object>
            {
                {"AggregateType",typeof(T).FullName},
            };
            connection.AppendToStream(streamName, ExpectedVersion.Any, DomainEventToEventData(@event.ID, @event, metadata));
        }
    }
}
