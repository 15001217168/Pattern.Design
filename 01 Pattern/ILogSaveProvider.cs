namespace _01_Pattern
{
    using Entity;
    public interface ILogSaveProvider
    {
        bool SaveLog(LogEntity entity);
    }
}
