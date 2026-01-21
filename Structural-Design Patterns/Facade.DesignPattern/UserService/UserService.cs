public class UserService : IUserService
{
    public bool CreateUser(string UserName, string email, string HashPassword)
    {
        // Simple user creation logic
        Console.WriteLine($"User {UserName} created with email {email}.");
        return true;
    }
}
