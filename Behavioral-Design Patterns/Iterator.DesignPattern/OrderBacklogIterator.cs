/// <summary>
/// Concrete Iterator - GoF style traversal over OrderBacklog.
/// Uses a traversal strategy to build an index map, then walks it.
/// </summary>
public sealed class OrderBacklogIterator : IIterator<Order>
{
    private readonly OrderBacklog _backlog;
    private readonly IOrderTraversalStrategy _strategy;
    private List<int> _orderedIndexes = [];
    private int _currentIndex;

    /// <summary>
    /// Creates a new iterator bound to a backlog and a traversal strategy.
    /// </summary>
    public OrderBacklogIterator(OrderBacklog backlog, IOrderTraversalStrategy strategy)
    {
        _backlog = backlog;
        _strategy = strategy;
        _currentIndex = 0;
    }

    /// <summary>
    /// Positions the cursor at the start of the traversal.
    /// The ordered index list is generated once per iteration.
    /// </summary>
    public void First()
    {
        _orderedIndexes = _strategy.GetOrderIndexes(_backlog.Items).ToList();
        _currentIndex = 0;
    }

    /// <summary>
    /// Advances the cursor to the next item.
    /// </summary>
    public void Next()
    {
        _currentIndex++;
    }

    /// <summary>
    /// Indicates whether the cursor has passed the last item.
    /// </summary>
    public bool IsDone => _currentIndex >= _orderedIndexes.Count;

    /// <summary>
    /// Gets the current item. Throws if the iterator is out of range.
    /// </summary>
    public Order CurrentItem
    {
        get
        {
            if (IsDone)
            {
                throw new InvalidOperationException("Iterator out of range.");
            }

            return _backlog[_orderedIndexes[_currentIndex]];
        }
    }
}