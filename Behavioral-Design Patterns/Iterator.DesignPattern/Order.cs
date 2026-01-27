/// <summary>
/// Domain entity representing a customer order.
/// Immutable to ensure safe traversal without side effects.
/// </summary>
public sealed class Order
{
    public string Id { get; }
    public string Customer { get; }
    public decimal Amount { get; }
    public OrderPriority Priority { get; }
    public DateTime CreatedAtUtc { get; }

    /// <summary>
    /// Creates a new order instance.
    /// </summary>
    public Order(string id, string customer, decimal amount, OrderPriority priority)
    {
        Id = id;
        Customer = customer;
        Amount = amount;
        Priority = priority;
        CreatedAtUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Formats the order data into a single, readable line for console output.
    /// </summary>
    public string ToDisplayString()
    {
        return $"{Id} | {Customer,-18} | {Priority,-8} | ${Amount,8:F2} | {CreatedAtUtc:yyyy-MM-dd HH:mm:ss} UTC";
    }
}
