namespace _06_01_Pattern.Events
{
    using Infrastructure;
    public class OrderAddEvent : IEvent
    {
        public string OrderId { get; set; }
    }
}
