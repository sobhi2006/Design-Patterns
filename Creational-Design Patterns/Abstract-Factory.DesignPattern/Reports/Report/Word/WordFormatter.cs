public class WordFormatter(string formatter) : IReportFormatter
{
    public void Format()
    {
        System.Console.WriteLine("Formatting report as Word: " + formatter);
    }
}