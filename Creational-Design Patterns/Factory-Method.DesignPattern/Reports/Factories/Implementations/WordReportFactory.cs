namespace Factory_Method.DesignPattern;

public class WordReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new WordReport();
    }
}