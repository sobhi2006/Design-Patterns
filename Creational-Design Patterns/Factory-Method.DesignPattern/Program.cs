namespace Factory_Method.DesignPattern;

public class Program
{
    public static void Main(string[] args)
    {
        ReportFactory reportFactory = ReportType.Pdf switch
        {
            ReportType.Pdf => new PdfReportFactory(),
            ReportType.Excel => new ExcelReportFactory(),
            ReportType.Word => new WordReportFactory(),
            _ => throw new NotSupportedException("Report type not supported")
        };
        IReportService reportService = new ReportService(reportFactory);
        reportService.Generate();
    }
}