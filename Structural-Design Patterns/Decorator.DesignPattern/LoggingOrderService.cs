public class LoggingOrderService : OrderDecorator
{
    private readonly ILogger<LoggingOrderService> _logger;
    public LoggingOrderService(IOrderService orderService, ILogger<LoggingOrderService> logger) : base(orderService)
    {
        this._logger = logger;
    }

    public override async Task CreateOrder(PlaceOrderDto request)
    {
        _logger.LogInformation("Starting to create order");
        await _orderService.CreateOrder(request);
        _logger.LogInformation("Order placed");
    }
}
