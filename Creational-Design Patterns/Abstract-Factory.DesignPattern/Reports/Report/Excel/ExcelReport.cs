
public class ExcelReport(string content) : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating Excel Report: " + content);
    }
}
