public interface INotificationSender
{
    public Task SendAsync(string to, string message); 
}
