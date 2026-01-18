
public class PdfReportFactory : ReportFactory
{
    public override IReportFormatter CreateFormatter(string formatter)
    {
        return new PdfFormatter(formatter);
    }

    public override IReport CreateReport(string content)
    {
        return new PdfReport(content);
    }

    public override IReportTemplate CreateTemplate(string template)
    {
        return new PdfTemplate(template);
    }
}
