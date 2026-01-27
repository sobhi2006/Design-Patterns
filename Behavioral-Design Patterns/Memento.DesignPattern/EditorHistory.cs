/// <summary>
/// Caretaker - stores Mementos without inspecting their internal state.
/// It orchestrates undo/redo using the Originator API only.
/// </summary>
public sealed class EditorHistory
{
    private readonly Stack<IMemento> _undoStack = new();
    private readonly Stack<IMemento> _redoStack = new();

    /// <summary>
    /// Saves the current editor state to the undo stack.
    /// Clears the redo stack when a new action is taken.
    /// </summary>
    public void SaveState(DocumentEditor editor)
    {
        if (editor == null)
            throw new ArgumentNullException(nameof(editor));

        _undoStack.Push(editor.Save());
        _redoStack.Clear(); // Clear redo history when a new action is taken
    }

    /// <summary>
    /// Reverts the editor to the previous saved state.
    /// </summary>
    public bool Undo(DocumentEditor editor)
    {
        if (editor == null)
            throw new ArgumentNullException(nameof(editor));

        if (_undoStack.Count == 0)
        {
            Console.WriteLine("❌ Nothing to undo.");
            return false;
        }

        // Save current state to redo stack
        _redoStack.Push(editor.Save());

        // Restore previous state
        var memento = _undoStack.Pop();
        editor.Restore(memento);
        return true;
    }

    /// <summary>
    /// Reapplies a previously undone state.
    /// </summary>
    public bool Redo(DocumentEditor editor)
    {
        if (editor == null)
            throw new ArgumentNullException(nameof(editor));

        if (_redoStack.Count == 0)
        {
            Console.WriteLine("❌ Nothing to redo.");
            return false;
        }

        // Save current state to undo stack
        _undoStack.Push(editor.Save());

        // Restore next state
        var memento = _redoStack.Pop();
        editor.Restore(memento);
        return true;
    }

    /// <summary>
    /// Gets the number of available undo operations.
    /// </summary>
    public int GetUndoCount() => _undoStack.Count;

    /// <summary>
    /// Gets the number of available redo operations.
    /// </summary>
    public int GetRedoCount() => _redoStack.Count;

    /// <summary>
    /// Clears all saved history.
    /// </summary>
    public void ClearHistory()
    {
        _undoStack.Clear();
        _redoStack.Clear();
    }
}