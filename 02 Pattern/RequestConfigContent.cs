
namespace _02_Pattern
{
    using System;

    public class RequestConfigContent
    {
        public static RequestConfigContent configContent = new RequestConfigContent();

        public string Formal { get; set; }
        public int Size { get; set; }
        public RequestProtocol Protocol { get; set; }
        public Func<RequestContent, bool> SafetyChecks { get; set; }
    }
}
