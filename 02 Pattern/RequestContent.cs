namespace _02_Pattern
{
    /// <summary>
    /// 请求上下文
    /// </summary>
    public class RequestContent
    {
        /// <summary>
        /// 请求内容格式
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public RequestProtocol Protocol { get; set; }

        public string Content { get; set; }
    }
}
