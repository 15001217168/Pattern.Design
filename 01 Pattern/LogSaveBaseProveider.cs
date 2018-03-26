
namespace _01_Pattern
{
    using System;
    using Entity;
    using System.Configuration;

    public abstract class LogSaveBaseProveider : ILogSaveProvider
    {
        public bool SaveLog(LogEntity entity)
        {
            if (!this.IsSaveLogWithConfiguration(entity)) return false;
            if (!this.ValidatorLogEntity(entity)) return false;
            this.FormatLogContent(entity);
            return this.DoSaveLog(entity);
        }
        protected virtual bool IsSaveLogWithConfiguration(LogEntity entity)
        {
            string logType = ConfigurationManager.AppSettings["LogType"];
            if (entity.Type.Equals(logType))
            {
                return true;
            }
            return false;
        }
        protected virtual bool ValidatorLogEntity(LogEntity entity)
        {
            if (entity == null || entity.Content == null)
            {
                return false;
            }
            return true;
        }
        protected virtual void FormatLogContent(LogEntity entity)
        {
            //对日志内容进行格式化
        }
        protected abstract bool DoSaveLog(LogEntity entity);
    }
}
