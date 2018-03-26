namespace _06_01_Pattern.Events
{
    using Infrastructure;
    using Aggregate;
    using System;

    public class NewApplicationAddedEvent : Event<ApplicationAggregate>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid ApplicationId { get; set; }

        public NewApplicationAddedEvent(string name, string surname, Guid applicationId)
        {
            Name = name;
            Surname = surname;
            ApplicationId = applicationId;
        }
    }
}
