public class OrderService : IOrderService
{
    public async Task CreateOrder(PlaceOrderDto request)
    {
        // Simulate to create order
        System.Console.WriteLine($"OrderId: {request.OrderId}, UserId: {request.UserId}, Quantity: {request.Quantity}\n\n\n\n");
        await Task.Delay(1000);
    }
}
