namespace _05_Pattern
{
    using System;
    using Entity;
    using System.Linq;

    [Serializable]
    public class Infomationer
    {
        public bool CheckPrices(Order order, ref OrderExamineApproveManagerHanlder manager)
        {
            if (order.Items.Any(item => item.Product.Price <= 0) ? false : true)
            {
                manager -= this.CheckPrices;
                return true;
            }
            return false;
        }
        public bool CheckNumber(Order order, ref OrderExamineApproveManagerHanlder manager)
        {
            if (order.Items.Any(item => item.Number > 10) ? false : true)
            {
                manager -= this.CheckNumber;
                return true;
            }
            return false;
        }
    }
}
