/// <summary>
/// Memento - GoF narrow interface exposed to the Caretaker.
/// It allows metadata inspection without revealing internal state.
/// </summary>
public interface IMemento
{
    string GetName();
    DateTime GetTimestamp();
}
