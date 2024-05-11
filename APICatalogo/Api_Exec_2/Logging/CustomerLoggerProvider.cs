using System.Collections.Concurrent;

namespace Api_Exec_2.Logging
{
    public class CustomerLoggerProvider : ILoggerProvider
    {
        readonly CustomerLoggerConfiguration _loggerConfigs;

        readonly ConcurrentDictionary<string, CustomerLogger> _Loggers =
            new ConcurrentDictionary<string, CustomerLogger>();

        public CustomerLoggerProvider(CustomerLoggerConfiguration logerConfigs)
        {
            _loggerConfigs = logerConfigs;
        }
        public ILogger CreateLogger(string categoryName)
        {
            _Loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, _loggerConfigs));
        }

        public void Dispose()
        {
            _Loggers.Clear();
        }
    }
}