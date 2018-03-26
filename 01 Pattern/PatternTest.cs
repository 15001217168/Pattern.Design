namespace _01_Pattern
{
    using Entity;
    public class PatternTest
    {
        public static void Test()
        {
            LogEntity log = new LogEntity();
            log.Type = LogType.ApplicationTrack;
            log.Level = LogLevel.Warning;
            log.Content.Message = "测试";
            ILogSaveProvider service = new LogSaveLocalhostProvider();
            service.SaveLog(log);

        }
    }
}
