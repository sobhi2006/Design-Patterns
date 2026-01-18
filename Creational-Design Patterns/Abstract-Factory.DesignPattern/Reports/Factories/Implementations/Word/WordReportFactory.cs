
public class WordReportFactory : ReportFactory
{
    public override IReportFormatter CreateFormatter(string formatter)
    {
        return new WordFormatter(formatter);
    }

    public override IReport CreateReport(string content)
    {
        return new WordReport(content);
    }

    public override IReportTemplate CreateTemplate(string template)
    {
        return new WordTemplate(template);
    }
}