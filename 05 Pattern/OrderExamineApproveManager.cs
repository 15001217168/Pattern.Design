namespace _05_Pattern
{
    using Entity;

    public delegate bool OrderExamineApproveManagerHanlder(Order order, ref OrderExamineApproveManagerHanlder manager);
    public class OrderExamineApproveManager
    {
        public static OrderExamineApproveManager CreateFlows()
        {
            OrderExamineApproveManager result = new OrderExamineApproveManager();

            Infomationer info = new Infomationer();

            result.Flows += info.CheckPrices;
            result.Flows += info.CheckNumber;

            return result;
        }

        public OrderExamineApproveManagerHanlder Flows;

        public void RunFlows(Order order)
        {
            this.Flows(order, ref this.Flows);
        }
    }
}
