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

        Console.WriteLine("Editing Document...\n");

        // Initial state
        editor.WriteContent("Hello, World!");
        Console.WriteLine($" Content: {editor.GetContent()}");
        Console.WriteLine($" Font Size: {editor.FontSize}pt | Color: {editor.TextColor}\n");

        // Save to history (checkpoint 1)
        history.SaveState(editor);
        Console.WriteLine("Checkpoint 1 saved.\n");

        // Modify content
        editor.WriteContent("Hello, Design Patterns!");
        editor.SetFontSize(14);
        editor.SetTextColor("Blue");
        Console.WriteLine($"Content: {editor.GetContent()}");
        Console.WriteLine($"Font Size: {editor.FontSize}pt | Color: {editor.TextColor}\n");

        // Save to history (checkpoint 2)
        history.SaveState(editor);
        Console.WriteLine("Checkpoint 2 saved.\n");

        // More modifications
        editor.WriteContent("Hello, Behavioral Patterns!");
        editor.SetFontSize(18);
        editor.SetTextColor("Red");
        Console.WriteLine($"Content: {editor.GetContent()}");
        Console.WriteLine($"Font Size: {editor.FontSize}pt | Color: {editor.TextColor}\n");

        Console.WriteLine("------- UNDO HISTORY -------\n");

        // Undo to checkpoint 2
        Console.WriteLine("⏮ Undoing to Checkpoint 2...\n");
        history.Undo(editor);
        Console.WriteLine($"  Content: {editor.GetContent()}");
        Console.WriteLine($"Font Size: {editor.FontSize}pt | Color: {editor.TextColor}\n");

        // Undo to checkpoint 1
        Console.WriteLine("⏮  Undoing to Checkpoint 1...\n");
        history.Undo(editor);
        Console.WriteLine($" Content: {editor.GetContent()}");
        Console.WriteLine($"Font Size: {editor.FontSize}pt | Color: {editor.TextColor}\n");

        Console.WriteLine("------- REDO HISTORY -------\n");

        // Redo to checkpoint 2
        Console.WriteLine("⏭ Redoing to Checkpoint 2...\n");
        history.Redo(editor);
        Console.WriteLine($" Content: {editor.GetContent()}");
        Console.WriteLine($"Font Size: {editor.FontSize}pt | Color: {editor.TextColor}\n");

        Console.WriteLine(new string('═', 80));
        Console.WriteLine("✅ KEY TAKEAWAY:");
        Console.WriteLine("   The Memento pattern captures object state in snapshots,");
        Console.WriteLine("   enabling undo/redo without exposing internal details.");
        Console.WriteLine(new string('═', 80));
    }
}
