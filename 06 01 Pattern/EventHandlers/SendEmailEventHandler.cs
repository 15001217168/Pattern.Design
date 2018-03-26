namespace _06_01_Pattern.EventHandlers
{
    using Infrastructure;
    using Events;
    using System;

    public class SendEmailEventHandler : IEventHandler<OrderAddEvent>, IEventHandler<OrderConfirmEvent>
    {
        public void Handle(OrderConfirmEvent evt)
        {
            Console.WriteLine("Order_Number:{0},Send AddConfirm a Email.", evt.OrderId);
        }

        public void Handle(OrderAddEvent evt)
        {
            Console.WriteLine("Order_Number:{0},Send AddOrder a Email.", evt.OrderId);
        }
    }
}
