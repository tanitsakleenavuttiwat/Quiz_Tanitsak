using log4net;
using Quiz_Tanitsak_Api.Interface;
using System.Reflection;

namespace Quiz_Tanitsak_Api.Helper
{
    public class LoggerInfo : ILoggerInfo
    {
        private readonly ILog _logger;
        public LoggerInfo()
        {
            this._logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        }

        public void Debug(string message)
        {
            this._logger?.Debug(message);
        }

        public void Error(string message, Exception? ex = null)
        {
            this._logger?.Error(message, ex?.InnerException);
        }

        public void Info(string message)
        {
            this._logger?.Info(message);
        }
    }
}
