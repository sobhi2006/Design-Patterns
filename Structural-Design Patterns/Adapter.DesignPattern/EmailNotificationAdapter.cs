public class EmailNotificationAdapter : INotificationSender
{
    private readonly EmailNotificationSender _emailSender;
    private readonly string subject;

    public EmailNotificationAdapter(EmailNotificationSender emailSender, string subject)
    {
        _emailSender = emailSender;
        this.subject = subject;
    }

    public Task SendAsync(string to, string message)
    {
        return _emailSender.SendEmailAsync(to, message, subject);
    }
}