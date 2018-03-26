namespace _06_01_Pattern.Events
{
    using Infrastructure;
    public class OrderConfirmEvent : IEvent
    {
        public string OrderId { get; set; }
    }
}
