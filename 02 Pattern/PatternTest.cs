
namespace _02_Pattern
{
    using System;

    public class PatternTest
    {
        public static void Test()
        {
            RequestConfigManager.Config.SetGlobalRequestSize(10).SetGlobalRequestProtocal(new RequestProtocol(RequestProtocol.InternalSoa)).SetGlobalRequestFormatJson().SetGlobalRequestFormatXml();
            int size = RequestConfigContent.configContent.Size;
            Console.Write(size);
        }
    }
}
