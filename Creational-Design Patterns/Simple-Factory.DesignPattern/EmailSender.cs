public class EmailSender : ISender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}