public class WhatsAppSender : ISender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending WhatsApp Message: {message}");
    }
}