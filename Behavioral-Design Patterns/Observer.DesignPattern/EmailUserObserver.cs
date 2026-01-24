public class EmailUserObserver : IUserObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Email User received message: {message}");
    }
}
