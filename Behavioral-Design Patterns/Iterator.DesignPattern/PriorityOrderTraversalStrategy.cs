/// <summary>
/// Traversal strategy that orders results by priority:
/// Critical → High → Standard → Low.
/// </summary>
public sealed class PriorityOrderTraversalStrategy : IOrderTraversalStrategy
{
    public IEnumerable<int> GetOrderIndexes(IReadOnlyList<Order> orders)
    {
        var priorities = new[]
        {
            OrderPriority.Critical,
            OrderPriority.High,
            OrderPriority.Standard,
            OrderPriority.Low
        };

        foreach (var priority in priorities)
        {
            for (var i = 0; i < orders.Count; i++)
            {
                if (orders[i].Priority == priority)
                {
                    yield return i;
                }
            }
        }
    }
}
