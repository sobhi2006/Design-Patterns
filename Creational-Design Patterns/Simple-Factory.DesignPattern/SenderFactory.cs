public class SenderFactory
{
    public static ISender Send(SendType sendType)
    {
        return sendType switch
        {
            SendType.Email => new EmailSender(),
            SendType.SMS => new SMSSender(),
            SendType.WhatsApp => new WhatsAppSender(),
            _ => throw new ArgumentException("Invalid send type")
        };
    }
}