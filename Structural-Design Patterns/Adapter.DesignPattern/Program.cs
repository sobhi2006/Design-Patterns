public class Program
{
    public static async Task Main(string[] args)
    {
        INotificationSender OldSender = new SmsNotificationSender();
        await OldSender.SendAsync("+1234567890", "Hello via SMS!");

        INotificationSender NewSender = new EmailNotificationAdapter(new EmailNotificationSender(), "Greetings");
        await NewSender.SendAsync("user@example.com", "Hello via Email!");
    }
}
