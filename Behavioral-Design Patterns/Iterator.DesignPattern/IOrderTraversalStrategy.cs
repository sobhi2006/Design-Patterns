/// <summary>
/// Strategy abstraction that defines how the backlog should be traversed.
/// Returns the indexes in the desired order.
/// </summary>
public interface IOrderTraversalStrategy
{
    IEnumerable<int> GetOrderIndexes(IReadOnlyList<Order> orders);
}
