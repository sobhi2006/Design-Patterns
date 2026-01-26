
public class Program
{
    public static void Main(string[] args)
    {
        var tradingSystem = new TradingSystem();
        var broker = new Broker();

        // Create commands
        var buyApple = new BuyStockCommand(tradingSystem, "AAPL", 100);
        var sellGoogle = new SellStockCommand(tradingSystem, "GOOGL", 50);

        // Execute commands via broker
        broker.TakeOrder(buyApple);
        broker.TakeOrder(sellGoogle);

        broker.UndoLastOrder();
    }
}
