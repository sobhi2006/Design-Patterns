namespace Factory_Method.DesignPattern;

public class ExcelReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new ExcelReport();
    }
}
