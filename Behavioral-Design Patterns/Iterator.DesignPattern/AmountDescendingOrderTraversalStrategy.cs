/// <summary>
/// Traversal strategy that orders results by amount (descending).
/// </summary>
public sealed class AmountDescendingOrderTraversalStrategy : IOrderTraversalStrategy
{
    public IEnumerable<int> GetOrderIndexes(IReadOnlyList<Order> orders)
    {
        foreach (var index in orders
                     .Select((order, index) => new { order.Amount, Index = index })
                     .OrderByDescending(x => x.Amount)
                     .Select(x => x.Index))
        {
            yield return index;
        }
    }
}
