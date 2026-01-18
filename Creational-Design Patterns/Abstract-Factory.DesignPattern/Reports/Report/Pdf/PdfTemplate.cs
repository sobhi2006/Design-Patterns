public class PdfTemplate(string template) : IReportTemplate
{
    public void Template()
    {
        System.Console.WriteLine("Generating PDF report with template: " + template);
    }
}