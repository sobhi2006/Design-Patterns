
public class ReportService : IReportService
{
    private readonly ReportFactory _reportFactory;
    private readonly string _content;
    private readonly string _formatter;
    private readonly string _template;

    public ReportService(ReportFactory reportFactory, string content, string formatter, string template)
    {
        _reportFactory = reportFactory;
        _content = content;
        _formatter = formatter;
        _template = template;
    }

    public void Generate()
    {
        var report = _reportFactory.CreateReport(_content);
        var formatter = _reportFactory.CreateFormatter(_formatter);
        var template = _reportFactory.CreateTemplate(_template);
        report.Generate();
        formatter.Format();
        template.Template();
    }
}