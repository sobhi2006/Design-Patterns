public class ExcelTemplate(string template) : IReportTemplate
{
    public void Template()
    {
        System.Console.WriteLine("Generating Excel report with template: " + template);
    }
}