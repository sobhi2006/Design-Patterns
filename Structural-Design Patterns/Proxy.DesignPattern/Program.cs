using System.Collections.ObjectModel;

public class Program
{
    public static async Task Main(string[] args)
    {
        IReportService reportService = new ReportServiceProxy(new ReportService());
        var report1 = await reportService.GetReportAsync(1);
        System.Console.WriteLine(report1);

        System.Console.WriteLine();

        var report2 = await reportService.GetReportAsync(1);
        System.Console.WriteLine(report2);
    }
}
