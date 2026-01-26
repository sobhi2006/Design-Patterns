public class SellStockCommand(TradingSystem tradingSystem, string stock, int quantity) : ITradeCommand
{
    private readonly TradingSystem _tradingSystem = tradingSystem;
    private readonly string _stock = stock;
    private readonly int _quantity = quantity;

    public void Execute()
    {
        _tradingSystem.Sell(_stock, _quantity);
    }

    public void Undo()
    {
        _tradingSystem.Buy(_stock, _quantity);
    }
}
