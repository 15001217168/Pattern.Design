
namespace _05_Pattern.Entity
{
    using System.Collections.Generic;

    public class Order
    {
        public string OrderId { get; set; }
        public CustomerInfo Customer { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
