public class EmailService : IEmailService
{
    public bool IsValidEmail(string email)
    {
        // Simple email validation logic
        return email.Contains('@') && email.Contains('.');
    }
}
