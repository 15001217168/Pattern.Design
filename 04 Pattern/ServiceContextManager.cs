
namespace _04_Pattern
{
    using System;
    public class ServiceContextManager
    {
        /// <summary>
        /// 当前上下文属性
        /// </summary>
        public SoaServiceCallContext CurrentContext
        {
            get
            {
                return SoaServiceCallContext.context;
            }
        }

        /// <summary>
        /// 感知服务调用上下文
        /// </summary>
        /// <param name="request"></param>
        protected void ApperceiveContext(Request request)
        {
            if (SoaServiceCallContext.context != null)
            {
                request.LogTrackID = CurrentContext.LogTrack ? Guid.NewGuid() : new Guid();
                request.TransactionID = CurrentContext.Transaction ? Guid.NewGuid() : new Guid();
            }
        }
    }
}
