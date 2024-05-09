using System.Collections.Concurrent;

namespace ApiExecUm.Logging.Services
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        readonly CustomLoggerProviderConfiguration _loggerConfigs;
        readonly ConcurrentDictionary<string, CustomerLogger> _Loggers =
            new ConcurrentDictionary<string, CustomerLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerOptions)
        {
            _loggerConfigs = loggerOptions;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _Loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, _loggerConfigs));
        }

        public void Dispose()
        {
            _Loggers.Clear();
        }
    }
}
