public class ExcelFormatter(string formatter) : IReportFormatter
{
    public void Format()
    {
        System.Console.WriteLine("Formatting report as Excel: " + formatter);
    }
}