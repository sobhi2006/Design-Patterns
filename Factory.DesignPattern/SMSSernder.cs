public class SMSSender : ISender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}