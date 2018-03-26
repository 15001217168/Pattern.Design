namespace _02_Pattern
{
    public class RequestProtocol
    {
        public const string Soap = "Soap";
        public const string InternalSoa = "InternalSoa";

        private string _protocol;

        public RequestProtocol(string protocol)
        {
            _protocol = protocol;
        }
    }
}
