namespace _05_Pattern
{
    using Entity;
    using System.Collections.Generic;
    public class PatternTest
    {
        public static void Test()
        {
            Order order = new Order()
            {
                Items = new List<OrderItem>(),
                Customer = new CustomerInfo() { Email = "123@qq.com", Phone = "123", Name = "123" }
            };
            order.Items.Add(new OrderItem() { Number = 10, Product = new Product() { Name = "自行车", Price = 100 } });
            order.Items.Add(new OrderItem() { Number = 1, Product = new Product() { Name = "齿轮", Price = 100 } });


            OrderExamineApproveManager approveFlows = OrderExamineApproveManager.CreateFlows();


        }
    }
}
