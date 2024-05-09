namespace ApiExecUm.Logging.Services
{
    public class CustomerLogger : ILogger
    {
        readonly string _LoggerName;
        readonly CustomLoggerProviderConfiguration _LoggerConfig;

        public CustomerLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            _LoggerName = loggerName;
            _LoggerConfig = loggerConfig;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _LoggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
          
            string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            if (IsEnabled(logLevel))
            {
                CreateLog(message, _LoggerConfig.Path);
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
