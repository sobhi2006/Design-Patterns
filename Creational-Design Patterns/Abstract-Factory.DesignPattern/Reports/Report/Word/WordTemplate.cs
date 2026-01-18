public class WordTemplate(string template) : IReportTemplate
{
    public void Template()
    {
        System.Console.WriteLine("Generating Word report with template: " + template);
    }
}