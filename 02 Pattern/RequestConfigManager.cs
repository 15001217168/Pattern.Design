namespace _02_Pattern
{
    public class RequestConfigManager
    {
        /// <summary>
        /// 使用单例模式的请求上下文对象
        /// </summary>
        public static RequestConfigManager Config = new RequestConfigManager();

        public RequestConfigManager SetGlobalRequestFormatJson()
        {
            if (string.IsNullOrEmpty(RequestConfigContent.configContent.Formal))
                RequestConfigContent.configContent.Formal = "Json";
            return this;
        }
        public RequestConfigManager SetGlobalRequestFormatXml()
        {
            if (string.IsNullOrEmpty(RequestConfigContent.configContent.Formal))
                RequestConfigContent.configContent.Formal = "Xml";
            return this;
        }
        public RequestConfigManager SetGlobalRequestProtocal(RequestProtocol protocol)
        {
            RequestConfigContent.configContent.Protocol = protocol;
            return this;
        }
        public RequestConfigManager SetGlobalRequestSize(int size)
        {
            RequestConfigContent.configContent.Size = size;
            return this;
        }
    }
}
