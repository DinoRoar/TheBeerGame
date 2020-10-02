using System;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;


namespace TheBeerGame.Client
{
    public class SerilogTypedLogger<T> : Microsoft.Extensions.Logging.ILogger<T>
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public SerilogTypedLogger(Serilog.ILogger logger)
        {
            using var logFactory = new SerilogLoggerFactory(logger);
            _logger = logFactory.CreateLogger(typeof(T).FullName);
        }

        IDisposable Microsoft.Extensions.Logging.ILogger.BeginScope<TState>(TState state) =>
            _logger.BeginScope<TState>(state);

        bool Microsoft.Extensions.Logging.ILogger.IsEnabled(LogLevel logLevel) =>
            _logger.IsEnabled(logLevel);

        void Microsoft.Extensions.Logging.ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) =>
            _logger.Log<TState>(logLevel, eventId, state, exception, formatter);
    }
}