namespace Quiz_Tanitsak_Api.Interface
{
    public interface ILoggerInfo
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message, Exception? ex = null);
    }
}
