public class CreateUserRequest : IRequest<int>
{
    public string Name { get; }
    public string Email { get; set; }
    public CreateUserRequest(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
