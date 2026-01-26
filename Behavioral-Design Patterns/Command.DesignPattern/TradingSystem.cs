public class TradingSystem
{
    public void Buy(string stock, int quantity)
    {
        Console.WriteLine($"Buying {quantity} shares of {stock}");
    }

    public void Sell(string stock, int quantity)
    {
        Console.WriteLine($"Selling {quantity} shares of {stock}");
    }
}
