﻿using Microsoft.Extensions.Logging;
using Models.Logs;
using System;

namespace EmailService.Services.Logs
{
    public class WebSocketLogger : ILogger
    {
        private readonly string category;

        public WebSocketLogger(string category)
        {
            this.category = category;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            LogsWebSocketHandler.Instance.SendLogMessage(new LogMessage
            {
                LogLevel = logLevel,
                EventId = eventId,
                Category = category,
                Message = formatter(state, exception),
                DateTime = DateTime.UtcNow
            });
        }
    }
}
