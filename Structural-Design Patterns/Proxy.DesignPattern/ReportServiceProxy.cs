public class ReportServiceProxy : IReportService
{
    private readonly IReportService _reportService;
    private Dictionary<int, string> _cachedReport = new();

    public ReportServiceProxy(IReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task<string> GetReportAsync(int id)
    {
        if (_cachedReport.TryGetValue(id, out var cachedReport))
        {
            System.Console.WriteLine("Returning cached report...");
            return cachedReport;
        }

        cachedReport = await _reportService.GetReportAsync(id);
        _cachedReport[id] = cachedReport;
        return cachedReport;
    }
}