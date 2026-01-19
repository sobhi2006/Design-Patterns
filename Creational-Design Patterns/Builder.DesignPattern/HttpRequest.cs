public class HttpRequest
{
    public string Url { get; }
    public HttpMethod Method { get; }
    public string? Body { get; }
    public IReadOnlyDictionary<string, string> Headers { get; }
    public IReadOnlyDictionary<string, string> QueryParameters { get; }
    public int Timeout { get; }
    public bool RequiresAuthentication { get; }
    internal HttpRequest(
        string url,
        HttpMethod method,
        string? body,
        IReadOnlyDictionary<string, string> headers,
        IReadOnlyDictionary<string, string> queryParameters,
        int timeout,
        bool requiresAuthentication)
    {
        Url = url;
        Method = method;
        Body = body;
        Headers = headers;
        QueryParameters = queryParameters;
        Timeout = timeout;
        RequiresAuthentication = requiresAuthentication;
    }

    public override string ToString()
    {
        return $"HttpRequest: \n     [Url={Url}], \n     Method={Method}, \n     Body={Body}, \n     Headers=[{string.Join(", ", Headers)}], \n     QueryParameters=[{string.Join(", ", QueryParameters)}], \n     Timeout={Timeout}, \n     RequiresAuthentication={RequiresAuthentication}]";
    }
}