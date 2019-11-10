namespace AOP.Services.Abstract
{
    public interface ILoggerService
    {
        void Info(object logMessage);
        void Debug(object logMessage);
        void Warn(object logMessage);
        void Fattal(object logMessage);
        void Error(object logMessage);
    }
}
