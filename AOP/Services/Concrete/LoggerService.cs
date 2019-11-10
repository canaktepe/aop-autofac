using AOP.Services.Abstract;
using log4net;

namespace AOP.Services.Concrete
{
    public class LoggerService : ILoggerService
    {
        private readonly ILog _logger;
        protected LoggerService(ILog logger)
        {
            _logger = logger;
        }

        private bool IsInfoEnabled => _logger.IsInfoEnabled;
        private bool IsDebugEnabled => _logger.IsDebugEnabled;
        private bool IsWarnEnabled => _logger.IsWarnEnabled;
        private bool IsFattalEnabled => _logger.IsFatalEnabled;
        private bool IsErrorEnabled => _logger.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
                _logger.Info(logMessage);
        }

        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
                _logger.Debug(logMessage);
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _logger.Warn(logMessage);
        }

        public void Fattal(object logMessage)
        {
            if (IsFattalEnabled)
                _logger.Fatal(logMessage);
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _logger.Error(logMessage);
        }
    }
}