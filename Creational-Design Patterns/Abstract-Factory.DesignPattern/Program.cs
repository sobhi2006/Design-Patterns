public class Program
{
    public static void Main(string[] args)
    {
        ReportFactory reportFactory = ReportType.Word switch
        {
            ReportType.Pdf => new PdfReportFactory(),
            ReportType.Excel => new ExcelReportFactory(),
            ReportType.Word => new WordReportFactory(),
            _ => throw new NotSupportedException("Report type not supported")
        };
        IReportService reportService = new ReportService(reportFactory, "Annual Report Content", "Standard Template", "Default Formatter");
        reportService.Generate();
    }
}