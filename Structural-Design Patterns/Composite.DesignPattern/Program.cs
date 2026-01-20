public class Program
{
    public static void Main(string[] args)
    {
        Thread.Sleep(10000);
        var laptop = new Product("Laptop", 1200m);
        var mouse = new Product("Mouse", 25m);
        var keyboard = new Product("Keyboard", 45m);

        var Bundle = new Bundle();
        Bundle.AddItem(laptop);
        Bundle.AddItem(mouse);
        Bundle.AddItem(keyboard);

        var Bundle2 = new Bundle();
        var monitor = new Product("Monitor", 300m);
        Bundle2.AddItem(monitor);
        Bundle2.AddItem(Bundle); // Nested bundle

        System.Console.WriteLine($"Total price of the bundle: ${Bundle.GetPrice()}");
    }
}

public interface IOrderItem
{
    decimal GetPrice();
}

public class Product : IOrderItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public decimal GetPrice()
    {
        return Price;
    }
}

public class Bundle : IOrderItem
{
    private List<IOrderItem> _items = new List<IOrderItem>();

    public void AddItem(IOrderItem item)
    {
        _items.Add(item);
    }

    public decimal GetPrice()
    {
        decimal total = 0;
        foreach (var item in _items)
        {
            total += item.GetPrice();
        }
        return total;
    }
}