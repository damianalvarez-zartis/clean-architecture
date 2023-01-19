using Microsoft.Extensions.Logging;

namespace TodoList.Infrastructure.Loggers
{
    public class TodoListLogger<T> : ToDoList.Core.Abstractions.Loggers.ILogger<T>
    {
        private readonly ILogger<T> _logger;
        public TodoListLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Debug(string message)
        {
            _logger.LogDebug(message);
        }

        public void Error(string message)
        {
            _logger.LogError(message);
        }

        public void Info(string message)
        {
            _logger.LogInformation(message);
        }

        public void Info(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void Warn(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
