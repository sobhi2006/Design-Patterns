/// <summary>
/// Entry point for the Memento (GoF) demonstration.
/// Uses Originator, Memento, and Caretaker roles per the GoF rules.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║            MEMENTO DESIGN PATTERN - Document Editor Demo                      ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════╝\n");

        var editor = new DocumentEditor();
        var history = new EditorHistory();

        Console.WriteLine("📝 Editing Document...\n");

        // Initial state
        editor.WriteContent("Hello, World!");
        Console.WriteLine($"✏️  Content: {editor.GetContent()}");
        Console.WriteLine($"📌 Font Size: {editor.FontSize}pt | 🎨 Color: {editor.TextColor}\n");

        // Save to history (checkpoint 1)
        history.SaveState(editor);
        Console.WriteLine("💾 Checkpoint 1 saved.\n");

        // Modify content
        editor.WriteContent("Hello, Design Patterns!");
        editor.SetFontSize(14);
        editor.SetTextColor("Blue");
        Console.WriteLine($"✏️  Content: {editor.GetContent()}");
        Console.WriteLine($"📌 Font Size: {editor.FontSize}pt | 🎨 Color: {editor.TextColor}\n");

        // Save to history (checkpoint 2)
        history.SaveState(editor);
        Console.WriteLine("💾 Checkpoint 2 saved.\n");

        // More modifications
        editor.WriteContent("Hello, Behavioral Patterns!");
        editor.SetFontSize(18);
        editor.SetTextColor("Red");
        Console.WriteLine($"✏️  Content: {editor.GetContent()}");
        Console.WriteLine($"📌 Font Size: {editor.FontSize}pt | 🎨 Color: {editor.TextColor}\n");

        Console.WriteLine("------- UNDO HISTORY -------\n");

        // Undo to checkpoint 2
        Console.WriteLine("⏮️  Undoing to Checkpoint 2...\n");
        history.Undo(editor);
        Console.WriteLine($"✏️  Content: {editor.GetContent()}");
        Console.WriteLine($"📌 Font Size: {editor.FontSize}pt | 🎨 Color: {editor.TextColor}\n");

        // Undo to checkpoint 1
        Console.WriteLine("⏮️  Undoing to Checkpoint 1...\n");
        history.Undo(editor);
        Console.WriteLine($"✏️  Content: {editor.GetContent()}");
        Console.WriteLine($"📌 Font Size: {editor.FontSize}pt | 🎨 Color: {editor.TextColor}\n");

        Console.WriteLine("------- REDO HISTORY -------\n");

        // Redo to checkpoint 2
        Console.WriteLine("⏭️  Redoing to Checkpoint 2...\n");
        history.Redo(editor);
        Console.WriteLine($"✏️  Content: {editor.GetContent()}");
        Console.WriteLine($"📌 Font Size: {editor.FontSize}pt | 🎨 Color: {editor.TextColor}\n");

        Console.WriteLine(new string('═', 80));
        Console.WriteLine("✅ KEY TAKEAWAY:");
        Console.WriteLine("   The Memento pattern captures object state in snapshots,");
        Console.WriteLine("   enabling undo/redo without exposing internal details.");
        Console.WriteLine(new string('═', 80));
    }
}

/// <summary>
/// Originator - owns the state that must be captured and restored.
/// Only the Originator can read/write the full state inside a Memento.
/// </summary>
public sealed class DocumentEditor
{
    private string _content = string.Empty;
    private int _fontSize = 12;
    private string _textColor = "Black";

    /// <summary>
    /// Gets the document content.
    /// </summary>
    public string Content => _content;

    /// <summary>
    /// Gets the font size in points.
    /// </summary>
    public int FontSize => _fontSize;

    /// <summary>
    /// Gets the text color.
    /// </summary>
    public string TextColor => _textColor;

    /// <summary>
    /// Replaces the document content.
    /// </summary>
    public void WriteContent(string text)
    {
        _content = text;
    }

    /// <summary>
    /// Gets the current document content.
    /// </summary>
    public string GetContent()
    {
        return _content;
    }

    /// <summary>
    /// Sets the font size for the document.
    /// </summary>
    public void SetFontSize(int size)
    {
        if (size < 8 || size > 72)
            throw new ArgumentException("Font size must be between 8 and 72 points.");
        _fontSize = size;
    }

    /// <summary>
    /// Sets the text color for the document.
    /// </summary>
    public void SetTextColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Color cannot be empty.");
        _textColor = color;
    }

    /// <summary>
    /// Creates a Memento that captures the current state.
    /// The Caretaker stores it without accessing internals.
    /// </summary>
    public IMemento Save()
    {
        return new EditorMemento(_content, _fontSize, _textColor);
    }

    /// <summary>
    /// Restores state from a Memento previously created by this Originator.
    /// </summary>
    public void Restore(IMemento memento)
    {
        if (memento is not EditorMemento editorMemento)
        {
            throw new ArgumentException("Invalid memento type.", nameof(memento));
        }

        _content = editorMemento.Content;
        _fontSize = editorMemento.FontSize;
        _textColor = editorMemento.TextColor;
    }

    /// <summary>
    /// Concrete Memento - encapsulates Originator state.
    /// Nested to restrict access to the state details.
    /// </summary>
    private sealed class EditorMemento : IMemento
    {
        public string Content { get; }
        public int FontSize { get; }
        public string TextColor { get; }
        public DateTime Timestamp { get; }

        public EditorMemento(string content, int fontSize, string textColor)
        {
            Content = content;
            FontSize = fontSize;
            TextColor = textColor;
            Timestamp = DateTime.UtcNow;
        }

        public string GetName()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] \"{Content}\" ({FontSize}pt, {TextColor})";
        }

        public DateTime GetTimestamp() => Timestamp;
    }
}

/// <summary>
/// Memento - GoF narrow interface exposed to the Caretaker.
/// It allows metadata inspection without revealing internal state.
/// </summary>
public interface IMemento
{
    string GetName();
    DateTime GetTimestamp();
}

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