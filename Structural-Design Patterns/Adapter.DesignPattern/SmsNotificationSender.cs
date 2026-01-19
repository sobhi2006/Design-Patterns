public class SmsNotificationSender : INotificationSender
{
    public Task SendAsync(string to, string message)
    {
        Console.WriteLine($"Sending SMS to {to}: {message}");
        return Task.CompletedTask;
    }
}
