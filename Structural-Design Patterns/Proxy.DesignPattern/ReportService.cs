public class ReportService : IReportService
{
    public async Task<string> GetReportAsync(int id)
    {
        System.Console.WriteLine("Fetching report from database...");
        // Simulate a time-consuming operation
        await Task.Delay(2000);
        return $"Report data with id: {id}.";
    }
}
