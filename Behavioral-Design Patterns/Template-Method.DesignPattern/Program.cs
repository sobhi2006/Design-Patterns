using System.Configuration.Assemblies;

public class Program
{
    public static void Main()
    {
        OrderTemplate order = new CreateOrderHandler(new CreateOrderDto(1, 1, 2));
        order.Process();
    }
}

public abstract class OrderTemplate
{
    public void Process()
    {
        Validation();
        Logging();
        Save();
    }
    public abstract void Validation();
    public abstract void Logging();
    public virtual void Save()
    {
        System.Console.WriteLine("Save Process of Order");
    }
}
public record CreateOrderDto(int ProductId, int UserId, int Quantity);
public class CreateOrderHandler(CreateOrderDto dto) : OrderTemplate
{
    public override void Logging()
    {
        System.Console.WriteLine("Log Create Order");
    }

    public override void Validation()
    {
        if(dto.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");
        
        if(dto.ProductId < 1)
            throw new ArgumentException("product id must be greater than zero");
    }

    public override void Save()
    {
        System.Console.WriteLine("Save Create Order Process");
    }
}