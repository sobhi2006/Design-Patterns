public class LoggerUserObserver : IUserObserver
{
    private readonly ILogger<LoggerUserObserver> _logger;
    
    public LoggerUserObserver(ILogger<LoggerUserObserver> logger)
    {
        _logger = logger;
    }

    public void Update(string message)
    {
        _logger.LogInformation($"Logger User logged message: {message}");
    }
}
