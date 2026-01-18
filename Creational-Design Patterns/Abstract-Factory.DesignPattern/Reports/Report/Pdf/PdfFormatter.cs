public class PdfFormatter(string formatter) : IReportFormatter
{
    public void Format()
    {
        System.Console.WriteLine("Formatting report as PDF: " + formatter);
    }
}