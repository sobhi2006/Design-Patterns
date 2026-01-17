namespace Factory_Method.DesignPattern;

public class WordReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Generating Word Report");
    }
}
