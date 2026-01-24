public class CreateUserHandler : IRequestHandler<CreateUserRequest, int>
{
    public int Handle(CreateUserRequest request)
    {
        System.Console.WriteLine($"User Created: {request.Name}, {request.Email}");
        return Random.Shared.Next(1, 1000); // Simulate returning a user ID
    }
}
