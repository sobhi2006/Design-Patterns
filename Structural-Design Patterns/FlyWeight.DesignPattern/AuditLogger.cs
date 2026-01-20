public class AuditLogger : IAuditLogger
{
    private readonly LogFactory _logFactory = new();

    public void Log(OperationType operationType,
                    string serviceName,
                    LevelType levelType,
                    int userId,
                    string message)
    {
        LogFlyweight flyweight = _logFactory.GetFlyweight(operationType, serviceName, levelType);
        LogEntry logEntry = new(flyweight, DateTime.Now, userId, message);
        
        Console.WriteLine(logEntry);
    }
    public int GetTotalFlyweights()
    {
        return _logFactory.GetTotalFlyweights();
    }
}