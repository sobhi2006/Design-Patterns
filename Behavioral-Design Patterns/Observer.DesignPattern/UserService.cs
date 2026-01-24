public class UserService : IUserService
{
    private readonly IUserSubject _userSubject;

    public UserService(IUserSubject userSubject)
    {
        _userSubject = userSubject;
    }

    public void CreateUser(string name, string email)
    {
        System.Console.WriteLine("Create User in DB ...");
        // Logic to create user
        _userSubject.Notify($"User {name} with email {email} has been created.");
    }
}