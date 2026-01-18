
public class WordReport(string content) : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating Word Report: " + content);
    }
}
