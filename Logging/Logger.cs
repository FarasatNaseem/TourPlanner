namespace Logging
{
    using Microsoft.Extensions.Logging;
    public static class Logger
    {
        //Reference: https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/april/essential-net-logging-with-net-core
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();

        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
    }
}
