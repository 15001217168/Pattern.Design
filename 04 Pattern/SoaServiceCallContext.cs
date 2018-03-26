namespace _04_Pattern
{
    using System;

    /// <summary>
    /// soa服务调用上下文事件委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arg"></param>
    public delegate void SoaServiceCallContextHander<T>(T arg);

    /// <summary>
    /// soa服务调用上下文
    /// </summary>
    public class SoaServiceCallContext : IDisposable
    {
        internal static SoaServiceCallContext context;

        /// <summary>
        /// 是否开启事务
        /// </summary>
        public bool Transaction { get; private set; }

        /// <summary>
        /// 是否开启日志跟踪
        /// </summary>
        public bool LogTrack { get; private set; }

        public SoaServiceCallContext(bool transaction, bool logtrack)
        {
            this.Transaction = transaction;
            this.LogTrack = logtrack;
            SoaServiceCallContext.context = this;
        }

        private SoaServiceCallContextHander<LogTrackLocation> beginRecordLogTrackHander;

        public event SoaServiceCallContextHander<LogTrackLocation> BeginRecordLogTrackEvent
        {
            add
            {
                this.beginRecordLogTrackHander += value;
            }
            remove
            {
                if (this.beginRecordLogTrackHander != null)
                {
                    this.beginRecordLogTrackHander -= value;
                }
            }
        }

        private SoaServiceCallContextHander<TransactionActionInfo> transactionEndHander;
        public event SoaServiceCallContextHander<TransactionActionInfo> TransactionEndHander
        {
            add
            {
                this.transactionEndHander += value;
            }
            remove
            {
                if (this.transactionEndHander != null)
                {
                    this.transactionEndHander -= value;
                }
            }
        }
        public void Dispose()
        {
            this.beginRecordLogTrackHander = null;
            this.transactionEndHander = null;
        }

        public void Run(TransactionActionInfo tr, LogTrackLocation log)
        {
            transactionEndHander(tr);
            beginRecordLogTrackHander(log);
        }
    }
}
