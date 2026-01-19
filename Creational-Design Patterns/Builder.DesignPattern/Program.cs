using System.Net;
public class Program
{
    public static void Main(string[] args)
    {
        var httpRequest = new HttpRequestBuilder()
            .SetUrl("https://api.example.com/data")
            .SetMethod(HttpMethod.POST)
            .SetBody("{ \"name\": \"example\" }")
            .AddHeader("Content-Type", "application/json")
            .AddHeader("Authorization", "Bearer token")
            .AddQueryParameter("version", "1.0")
            .SetTimeout(60)
            .SetRequiresAuthentication(true)
            .Build();
        System.Console.WriteLine(httpRequest);
    }
}