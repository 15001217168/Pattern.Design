namespace _06_01_Pattern.Aggregate
{
    using Events;
    using Infrastructure;
    using System;

    public class ApplicationAggregate : Aggregate
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime ApplicationDate { get; set; }

        private void Handle(NewApplicationAddedEvent @event)
        {
            Name = @event.Name;
            Surname = @event.Surname;
            ID = @event.ApplicationId;
            ApplicationDate = DateTime.Now;
        }

        //private void Handle(NameOnApplicationChangedEvent @event)
        //{
        //    Name = @event.Name;
        //    Surname = @event.Surname;
        //}
    }
}
