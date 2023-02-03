namespace ToDoList.Core.Abstractions.Loggers
{
    public interface ILogger
    {
        void Info(string message);
        void Info(string message, params object[] args);
        void Warn(string message);
        void Error(string message);
        void Debug(string message);
    }

    public interface ILogger<in T> : ILogger
    {
    }
}
