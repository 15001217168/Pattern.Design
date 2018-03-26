namespace _03_Pattern.Module.Client
{
    using Entity;
    using _03_Pattern;
    using System;

    /// <summary>
    /// 客户端Modules
    /// </summary>
    public class ClientPipelineModules
    {
        public static void CheckRequestContent(Request request)
        {
            if (request == null || request.Content == null || string.IsNullOrEmpty(request.Content.Content))
            {
                throw new InvalidOperationException("无效的请求");
            }
        }
        public static void AddRequestHead(Request request)
        {
            request.Head.Append("Request Source:SOA Client");
        }
        public static void TransferRequestFormat(Request request)
        {
            request.Content.Content = string.Format(request.Content.Content + "{0}", "转换成功");
        }
        public static void ReduceRequest(Request request)
        {
           //压缩对象
        }
    }
}
