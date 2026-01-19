public class EmailNotificationSender
{
    public Task SendEmailAsync(string emailAddress, string subject, string body)
    {
        Console.WriteLine($"Sending Email to {emailAddress}: {subject} - {body}");
        return Task.CompletedTask;
    }
}
