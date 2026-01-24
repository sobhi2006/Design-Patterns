var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedSingleton<IUserObserver, EmailUserObserver>("Email");
builder.Services.AddKeyedSingleton<IUserObserver, LoggerUserObserver>("Logger");
builder.Services.AddSingleton<IUserSubject>(sp =>
{
    IUserObserver publisher1 = sp.GetRequiredKeyedService<IUserObserver>("Email");
    IUserObserver publisher2 = sp.GetRequiredKeyedService<IUserObserver>("Logger");
    var observers = new List<IUserObserver> { publisher1, publisher2 };
    return new UserSubjectObserver(observers);
});
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.MapPost("/user/create", (IUserService userService) =>
{
    userService.CreateUser("John Doe", "john.doe@example.com");
    return Results.Created();
});

app.MapPost("/detach-event/{observerType}", (IUserSubject userSubject, string observerType, IServiceProvider sp) =>
{
    IUserObserver observer = sp.GetRequiredKeyedService<IUserObserver>(observerType);
    userSubject.Detach(observer);
    return Results.Ok("Deleted Successfully");
});

app.Run();
