

namespace _01_Pattern
{
    using System;
    using Entity;

    public class LogSaveLocalhostProvider : LogSaveBaseProveider
    {
        protected override bool ValidatorLogEntity(LogEntity entity)
        {
            if (base.ValidatorLogEntity(entity))
            {
                if (string.IsNullOrEmpty(entity.Content.LogTrackInfo)) return
                          false;
            }
            return true;
        }
        protected override void FormatLogContent(LogEntity entity)
        {
            entity.Content.Message = entity.Content.Message.Replace("\\", "--");
        }
        protected override bool DoSaveLog(LogEntity entity)
        {
            return true;
        }
    }
}
