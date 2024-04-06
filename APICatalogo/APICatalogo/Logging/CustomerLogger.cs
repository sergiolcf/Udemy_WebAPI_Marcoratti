
namespace APICatalogo.Logging
{
    public class CustomerLogger : ILogger// <- implementa a interface 'Ilogger', que define os métodos necessarios para registrar as mensagens de logger
    {
        readonly string _loggerName; // Receberá o nome da categoria/Componente
        readonly CustomerLoggerProviderConfiguration _providerConfiguration; //Receberá as configurações do provedor

        public CustomerLogger(string loggerName, CustomerLoggerProviderConfiguration providerConfiguration)
        {
            _loggerName = loggerName;
            _providerConfiguration = providerConfiguration;
        }
        public bool IsEnabled(LogLevel logLevel) // <- Verifica se o nível de log desejado esta habilidato na configuração, se não estiver habilitado as msg não serão registradas.
        {
            return logLevel == _providerConfiguration.LogLevel;
        }


        //Permite criar um escopo para as mensagens de log, neste exemplo não iremos utilizar
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

       
        //Chamado para registrar uma mensagem de log, fará a verificação se o nível de log é permitido, se for, irá usar o delegate 'Func Formatter' e vai escrever a mensagem no arquivo de log através do método 'EscreverTextoNoArquivo
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            EscreverTextoNoArquivo(mensagem);
        }

        //Escreverá a mensagem.
        private void EscreverTextoNoArquivo(string mensagem)
        {
            string caminhoArquivolog = @"D:\Web API ASP .Net 8 Core Essencial\Primeiro Projeto WebAPI\Udemy_WebAPI_Marcoratti\APICatalogo\Log\Macoratti_log.txt";

            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivolog, true))
            {
                try
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
