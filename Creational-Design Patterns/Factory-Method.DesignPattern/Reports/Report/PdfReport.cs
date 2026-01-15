namespace Factory_Method.DesignPattern;

public class PdfReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating PDF Report");
    }
}
