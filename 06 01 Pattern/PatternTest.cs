namespace _06_01_Pattern
{
    using EventHandlers;
    using Events;
    using Infrastructure;
    using System;
    using System.Text;

    public class PatternTest
    {
        public static void Test()
        {
            EventBus.Instance.Subscribe<OrderConfirmEvent>(new SendEmailEventHandler());
            EventBus.Instance.Subscribe<OrderAddEvent>(new SendEmailEventHandler());

            EventBus.Instance.Subscribe(new ActionDelegatedEventHandler<OrderAddEvent>(new Action<OrderAddEvent>(t =>
            {
                Console.WriteLine("使用委托：Order_Number:{0},Send a Email.", t.OrderId);
            })));
            EventBus.Instance.Subscribe(new ActionDelegatedEventHandler<OrderAddEvent>(t =>
            {
                Console.WriteLine("使用表达式：Order_Number:{0},Send a Email.", t.OrderId);
            }));

            var o = new ActionDelegatedEventHandler<OrderAddEvent>();
            o.AddActionDelegatedEvent += PatternTest_AddActionDelegatedEvent;
            EventBus.Instance.Subscribe(o);

            var orderAdd = new OrderAddEvent() { OrderId = "1234567" };
            var orderConfirm = new OrderConfirmEvent() { OrderId = "7654321" };

            EventBus.Instance.Publish(orderAdd);
            EventBus.Instance.Publish(orderConfirm);
        }

        private static void PatternTest_AddActionDelegatedEvent(OrderAddEvent evt)
        {
            Console.WriteLine("使用事件：Order_Number:{0},Send a Email.", evt.OrderId);
        }
    }
}
