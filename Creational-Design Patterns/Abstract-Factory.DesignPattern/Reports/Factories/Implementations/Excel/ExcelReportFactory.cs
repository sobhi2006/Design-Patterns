
public class ExcelReportFactory : ReportFactory
{
    public override IReportFormatter CreateFormatter(string formatter)
    {
        return new ExcelFormatter(formatter);
    }

    public override IReport CreateReport(string content)
    {
        return new ExcelReport(content);
    }

    public override IReportTemplate CreateTemplate(string template)
    {
        return new ExcelTemplate(template);
    }
}
