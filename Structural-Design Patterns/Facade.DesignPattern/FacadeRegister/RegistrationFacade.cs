public class RegistrationFacade : IRegistrationFacade
{
    private readonly IEmailService _emailService;
    private readonly IUserService _userService;
    private readonly IPasswordService _passwordService;

    public RegistrationFacade(IEmailService emailService, IUserService userService, IPasswordService passwordService)
    {
        _emailService = emailService;
        _userService = userService;
        _passwordService = passwordService;
    }

    public void RegisterUser(string userName, string email, string password)
    {
        if (!_emailService.IsValidEmail(email))
            throw new ArgumentException("Invalid Email Address.");

        string hashedPassword = _passwordService.HashPassword(password);

        if(!_userService.CreateUser(userName, email, hashedPassword))
            throw new Exception("User creation failed.");

        Console.WriteLine($"User: {userName} registered with email {email} and hashed password {hashedPassword}.");
    }
}