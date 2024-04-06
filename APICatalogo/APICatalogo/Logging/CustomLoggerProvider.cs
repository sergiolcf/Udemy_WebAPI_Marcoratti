using System.Collections.Concurrent;

namespace APICatalogo.Logging
{
    public class CustomLoggerProvider : ILoggerProvider // <- usada para criar instancias de logger personalizadas
    {
        readonly CustomerLoggerProviderConfiguration _loggerConfig;


        //Dicionario de Loggers <nome da categoria/Componente, Valor da instancia de customerLogger> >
        readonly ConcurrentDictionary<string, CustomerLogger> _loggers = 
            new ConcurrentDictionary<string, CustomerLogger>();


        //Recebe instancias do CustomerLoogerProviderconfiguration, que define a configuração de todos os loggers criados por este provedor. 
        public CustomLoggerProvider(CustomerLoggerProviderConfiguration customerLoggerConfig)
        {
            _loggerConfig = customerLoggerConfig;
        }
        public ILogger CreateLogger(string categoryName) // <- usado para criar logger para uma categoria especifica, retornar um logger existente do dicionario ou criar um novo.
        {
            return _loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, _loggerConfig));
        }

        public void Dispose() //<- liberando recursos quando o provedor for descartado
        {
            _loggers.Clear();   
        }
    }
}
