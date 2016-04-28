namespace Zad7.Interfaces
{
    public interface ILogger
    {
        void Write(string message, LogLevel level);
    }

    public enum LogLevel
    {
        FATAL,
        ERROR,
        WARN,
        INFO,
        DEBUG
    }
}
