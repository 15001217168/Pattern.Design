namespace _03_Pattern
{
    using Entity;
    public class RequestClientTypeFactory
    {
        public static RequestClientType CreateRequestClientTypeForApp()
        {
            return new RequestClientType() { type = RequestClientType.App };
        }
        public static RequestClientType CreateRequestClientTypeForNet()
        {
            return new RequestClientType() { type = RequestClientType.NetClient };
        }
    }
}
