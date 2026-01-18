
public abstract class ReportFactory
{
    public abstract IReport CreateReport(string content);
    public abstract IReportFormatter CreateFormatter(string formatter);
    public abstract IReportTemplate CreateTemplate(string template);
}
