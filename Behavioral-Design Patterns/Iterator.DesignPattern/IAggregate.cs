/// <summary>
/// GoF Aggregate abstraction.
/// Responsible for creating iterator instances.
/// </summary>
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
    IIterator<T> CreateIterator(IOrderTraversalStrategy strategy);
    void Add(T item);
}
