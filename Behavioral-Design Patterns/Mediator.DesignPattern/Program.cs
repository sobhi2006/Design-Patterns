using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMediator, Mediator>();
builder.Services.AddTransient<IRequestHandler<CreateUserRequest, int>, CreateUserHandler>();

var app = builder.Build();

app.MapPost("/", (IMediator mediator, [FromBody] CreateUserRequest request) =>
{
    var user = mediator.Send(request);  
    return $"User created with ID: {user}";
});

app.Run();
