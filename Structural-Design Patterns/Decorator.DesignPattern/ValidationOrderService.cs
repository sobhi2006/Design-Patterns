public class ValidationOrderService : OrderDecorator
{
    public ValidationOrderService(IOrderService orderService) : base(orderService)
    {
    }

    public override async Task CreateOrder(PlaceOrderDto request)
    {
        if(request.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");

        await _orderService.CreateOrder(request);
    }
}