public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        if(string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be null or empty.");

        // Simple password hashing logic (not secure, just for demonstration)
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
}
