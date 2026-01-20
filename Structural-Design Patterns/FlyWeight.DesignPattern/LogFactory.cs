public class LogFactory
{
    private readonly Dictionary<string, LogFlyweight> _flyweights = new();

    public LogFlyweight GetFlyweight(OperationType operationType, string serviceName, LevelType levelType)
    {
        string key = $"{operationType}_{serviceName}_{levelType}";

        if (!_flyweights.ContainsKey(key))
        {
            _flyweights[key] = new LogFlyweight(operationType, serviceName, levelType);
        }

        return _flyweights[key];
    }

    public int GetTotalFlyweights()
    {
        return _flyweights.Count;
    }
}
