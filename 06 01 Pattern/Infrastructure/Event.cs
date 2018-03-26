namespace _06_01_Pattern.Infrastructure
{
    using System;
    public class Event<T> where T : Aggregate
    {
        public Guid ID { get; set; }
        public Guid AggregateID { get; set; }

        public Event()
        {
            ID = Guid.NewGuid();
        }
    }
}
