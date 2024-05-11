
namespace Api_Exec_2.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly CustomerLoggerConfiguration _LoggerConfiguration;
        readonly string _LoggerName;

        public CustomerLogger(string loggerName, CustomerLoggerConfiguration loggerConfig)
        {
            _LoggerName = loggerName;
            _LoggerConfiguration = loggerConfig;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _LoggerConfiguration.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

                CreateLog(message, _LoggerConfiguration.Path);
            }
        }

        private void CreateLog(string message, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                try
                {
                    sw.WriteLine(message);
                    sw.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }
    }
}
