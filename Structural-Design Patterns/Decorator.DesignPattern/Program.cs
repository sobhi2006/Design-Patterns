using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IOrderService>(sp =>
{
    IOrderService service = sp.GetRequiredService<OrderService>();
    service = new ValidationOrderService(service);
    service = new LoggingOrderService(service, sp.GetRequiredService<ILogger<LoggingOrderService>>());

    return service;
});

var app = builder.Build();

app.MapGet("/", (IOrderService order, [FromBody]PlaceOrderDto dto) =>
{
    order.CreateOrder(dto);
});

app.Run();
