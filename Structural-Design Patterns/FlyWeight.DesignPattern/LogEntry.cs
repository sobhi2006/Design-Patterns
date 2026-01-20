public class LogEntry
{
    public LogFlyweight Flyweight { get; }
    public DateTime Timestamp { get; }
    public int UserId { get; }
    public string Message { get; }

    public LogEntry(LogFlyweight flyweight, DateTime timestamp, int userId, string message)
    {
        Flyweight = flyweight;
        Timestamp = timestamp;
        UserId = userId;
        Message = message;
    }

    public override string ToString()
    {
        return $"[{Timestamp}] [{Flyweight.LevelType}] [{Flyweight.ServiceName}] [{Flyweight.OperationType}] User:{UserId} - {Message}";
    }
}
