public abstract class OrderDecorator : IOrderService
{
    protected readonly IOrderService _orderService;

    public OrderDecorator(IOrderService orderService)
    {
        this._orderService = orderService;
    }

    public abstract Task CreateOrder(PlaceOrderDto request);
}
