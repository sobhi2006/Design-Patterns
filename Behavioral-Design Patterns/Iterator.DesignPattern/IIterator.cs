/// <summary>
/// GoF Iterator abstraction.
/// Provides cursor-style traversal without exposing the collection.
/// </summary>
public interface IIterator<out T>
{
    void First();
    void Next();
    bool IsDone { get; }
    T CurrentItem { get; }
}
