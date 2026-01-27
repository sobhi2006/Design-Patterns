/// <summary>
/// Entry point for the Iterator (GoF) demonstration.
/// The client interacts only with the Aggregate and Iterator abstractions,
/// while traversal behavior is swapped via Strategy objects.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║        ITERATOR PATTERN (GoF) - Order Backlog Demo            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

        // Client uses the Aggregate interface only (no knowledge of internal storage).
        IAggregate<Order> backlog = new OrderBacklog();
        backlog.Add(new Order("ORD-1001", "Acme Corp", 1520.50m, OrderPriority.Standard));
        backlog.Add(new Order("ORD-1002", "Globex", 9800.00m, OrderPriority.Critical));
        backlog.Add(new Order("ORD-1003", "Initech", 420.00m, OrderPriority.Low));
        backlog.Add(new Order("ORD-1004", "Umbrella", 7100.75m, OrderPriority.High));
        backlog.Add(new Order("ORD-1005", "Wayne Enterprises", 2300.00m, OrderPriority.Standard));

        // Client asks Aggregate to create a ConcreteIterator (default traversal).
        IIterator<Order> iterator = backlog.CreateIterator();

        Console.WriteLine("--- Traversal Using GoF Iterator (Insertion Order) ---");
        for (iterator.First(); !iterator.IsDone; iterator.Next())
        {
            Console.WriteLine(iterator.CurrentItem.ToDisplayString());
        }

        Console.WriteLine("\n--- Traversal Using Priority Strategy ---");
        IIterator<Order> priorityIterator = backlog.CreateIterator(new PriorityOrderTraversalStrategy());
        for (priorityIterator.First(); !priorityIterator.IsDone; priorityIterator.Next())
        {
            Console.WriteLine(priorityIterator.CurrentItem.ToDisplayString());
        }

        Console.WriteLine("\n--- Traversal Using Amount Strategy (High to Low) ---");
        IIterator<Order> amountIterator = backlog.CreateIterator(new AmountDescendingOrderTraversalStrategy());
        for (amountIterator.First(); !amountIterator.IsDone; amountIterator.Next())
        {
            Console.WriteLine(amountIterator.CurrentItem.ToDisplayString());
        }

        Console.WriteLine("\nKey Takeaway: Iterator traversal can be swapped using strategy objects.");
    }
}
