public class LogFlyweight
{
    public OperationType OperationType { get; }
    public string ServiceName { get; }
    public LevelType LevelType { get; }

    public LogFlyweight(OperationType operationType, string serviceName, LevelType levelType)
    {
        OperationType = operationType;
        ServiceName = serviceName;
        LevelType = levelType;
    }
}
