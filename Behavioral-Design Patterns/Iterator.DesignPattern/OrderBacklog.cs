/// <summary>
/// Concrete Aggregate - encapsulates the order collection and creates iterators.
/// Internal accessors are used only by iterator implementations.
/// </summary>
public sealed class OrderBacklog : IAggregate<Order>
{
    private readonly List<Order> _orders = [];

    /// <summary>
    /// Adds a new order to the backlog.
    /// </summary>
    public void Add(Order order)
    {
        _orders.Add(order);
    }

    /// <summary>
    /// Creates the default iterator (insertion order).
    /// </summary>
    public IIterator<Order> CreateIterator()
    {
        return new OrderBacklogIterator(this, new DefaultOrderTraversalStrategy());
    }

    /// <summary>
    /// Creates an iterator using the provided traversal strategy.
    /// </summary>
    public IIterator<Order> CreateIterator(IOrderTraversalStrategy strategy)
    {
        return new OrderBacklogIterator(this, strategy);
    }

    internal int Count => _orders.Count;

    internal Order this[int index] => _orders[index];

    internal IReadOnlyList<Order> Items => _orders;
}
