namespace _04_Pattern
{
    public class PatternTest
    {
        public static int i = 0;
        public static void Test()
        {
            ServiceProxy proxy = new ServiceProxy();
            using (SoaServiceCallContext soaContext = new SoaServiceCallContext(true, true))
            {
                soaContext.BeginRecordLogTrackEvent += SoaContext_BeginRecordLogTrackEvent;
                soaContext.TransactionEndHander += SoaContext_TransactionEndHander;

                proxy.SetTicketPrice("1", 2);
                TransactionActionInfo t = new TransactionActionInfo();
                LogTrackLocation l = new LogTrackLocation();
                soaContext.Run(t, l);
            }
        }

        private static void SoaContext_TransactionEndHander(TransactionActionInfo arg)
        {
            i += 1;
        }

        private static void SoaContext_BeginRecordLogTrackEvent(LogTrackLocation arg)
        {
            i += 1;
        }
    }
}
