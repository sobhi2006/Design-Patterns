
public class PdfReport(string content) : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating PDF Report: " + content);
    }
}
