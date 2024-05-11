namespace Api_Exec_2.Logging
{
    public class CustomerLoggerConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
        public string Path { get; set; }
    }
}