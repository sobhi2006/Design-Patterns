namespace Strategy.DesignPattern;

/// <summary>
/// Context Class - The ShoppingCart that uses payment strategies.
/// This class maintains a reference to a Strategy object and delegates
/// the payment processing to it. The Context doesn't know the concrete
/// class of a strategy - it works with all strategies via the Strategy interface.
/// </summary>
public class ShoppingCart
{
    private readonly List<(string Name, decimal Price, int Quantity)> _items = [];
    private IPaymentStrategy? _paymentStrategy;

    /// <summary>
    /// Sets the payment strategy at runtime.
    /// This allows changing the payment method dynamically.
    /// </summary>
    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
        Console.WriteLine($"📋 Payment strategy set to: {paymentStrategy.GetType().Name}");
    }

    public void AddItem(string name, decimal price, int quantity = 1)
    {
        _items.Add((name, price, quantity));
        Console.WriteLine($"🛒 Added: {name} x{quantity} @ ${price:F2} each");
    }

    public void RemoveItem(string name)
    {
        var item = _items.FirstOrDefault(i => i.Name == name);
        if (item != default)
        {
            _items.Remove(item);
            Console.WriteLine($"🗑️  Removed: {name}");
        }
    }

    public decimal CalculateTotal()
    {
        return _items.Sum(item => item.Price * item.Quantity);
    }

    public void DisplayCart()
    {
        Console.WriteLine("\n╔══════════════════════════════════════════════╗");
        Console.WriteLine("║            🛍️  SHOPPING CART                  ║");
        Console.WriteLine("╠══════════════════════════════════════════════╣");

        foreach (var item in _items)
        {
            var itemTotal = item.Price * item.Quantity;
            Console.WriteLine($"║  {item.Name,-20} {item.Quantity,3} x ${item.Price,8:F2} = ${itemTotal,8:F2} ║");
        }

        Console.WriteLine("╠══════════════════════════════════════════════╣");
        Console.WriteLine($"║  {"TOTAL:",-20} {"",-16} ${CalculateTotal(),8:F2} ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝\n");
    }

    /// <summary>
    /// Processes the checkout using the configured payment strategy.
    /// This is the key method that delegates to the strategy.
    /// </summary>
    public bool Checkout()
    {
        if (_paymentStrategy is null)
        {
            Console.WriteLine("❌ No payment method selected. Please set a payment strategy.");
            return false;
        }

        if (!_items.Any())
        {
            Console.WriteLine("❌ Your cart is empty. Please add items before checkout.");
            return false;
        }

        DisplayCart();

        var total = CalculateTotal();
        Console.WriteLine("═══════════════════════════════════════════════");
        Console.WriteLine("              PROCESSING PAYMENT               ");
        Console.WriteLine("═══════════════════════════════════════════════\n");

        var result = _paymentStrategy.ProcessPayment(total);

        if (result)
        {
            Console.WriteLine("\n🎉 Order completed successfully! Thank you for your purchase.");
            _items.Clear();
        }

        return result;
    }
}
