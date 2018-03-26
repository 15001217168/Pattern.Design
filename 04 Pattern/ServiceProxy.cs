namespace _04_Pattern
{
    public class ServiceProxy : ServiceContextManager
    {
        public void SetTicketPrice(string ticketid, int price)
        {
            base.ApperceiveContext(new ServiceProxyRequest() { TicketID = ticketid, Price = price });
        }
    }
}
