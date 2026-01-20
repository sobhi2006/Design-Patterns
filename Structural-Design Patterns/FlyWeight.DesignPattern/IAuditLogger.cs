public interface IAuditLogger
{
    void Log(OperationType operationType,
             string serviceName,
             LevelType levelType,
             int userId,
             string message);
    
    int GetTotalFlyweights();
}
