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
