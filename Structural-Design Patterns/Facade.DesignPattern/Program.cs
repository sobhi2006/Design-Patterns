public class Program
{
    public static void Main(string[] args)
    {
        IRegistrationFacade registrationFacade = new RegistrationFacade(
            new EmailService(),
            new UserService(),
            new PasswordService()
        );

        try
        {
            registrationFacade.RegisterUser("Client", "client@example.com", "password123");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
