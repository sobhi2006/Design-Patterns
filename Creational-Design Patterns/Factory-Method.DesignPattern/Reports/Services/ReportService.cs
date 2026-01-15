namespace Factory_Method.DesignPattern;

public class ReportService : IReportService
{
    private readonly ReportFactory _reportFactory;

    public ReportService(ReportFactory reportFactory)
    {
        _reportFactory = reportFactory;
    }

    public void Generate()
    {
        var report = _reportFactory.CreateReport();
        report.Generate();
    }
}