/// <summary>
/// Default traversal strategy (insertion order).
/// </summary>
public sealed class DefaultOrderTraversalStrategy : IOrderTraversalStrategy
{
    public IEnumerable<int> GetOrderIndexes(IReadOnlyList<Order> orders)
    {
        for (var i = 0; i < orders.Count; i++)
        {
            yield return i;
        }
    }
}
