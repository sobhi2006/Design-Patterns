namespace Factory_Method.DesignPattern;

public class ExcelReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating Excel Report");
    }
}
