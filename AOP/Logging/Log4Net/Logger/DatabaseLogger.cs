using AOP.Services.Concrete;
using log4net;

namespace AOP.Logging.Log4Net.Logger
{
    public class DatabaseLogger : LoggerService
    {
        public DatabaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }
    }
}
