using Microsoft.Extensions.Logging;
using System;
using static System.Console;

namespace Packt.CS7
{
    public class ConsoleLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        // logger가 관리되지 않는 리소스를 사용하면
        // 여기서 메모리를 해제한다. 
        public void Dispose() { }
    }

    public class ConsoleLogger : ILogger
    {
        // logger가 관리되지 않는 리소스를 사용하면
        // 여기서 IDisposable을 구현한 클래스를 반환할 수 있다. 
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // log level에 따라 로그를 필터한다. 
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                default:
                    return true;
            };
        }

        public void Log<TState>(LogLevel logLevel,
        EventId eventId, TState state, Exception exception,
        Func<TState, Exception, string> formatter)
        {
            // level과 eventId를 기록한다. 
            Write($"Level: {logLevel}, Event ID: {eventId.Id}, Event Name: {eventId.Name}");

            // state와 exception을 기록한다. 
            if (state != null)
            {
                //Write($", State: {state}");
            }
            if (exception != null)
            {
                Write($", Exception: {exception.Message}");
            }
            WriteLine();
        }
    }
}