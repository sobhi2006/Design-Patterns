public class HttpRequestBuilder
{
    public string Url { get; set; } = string.Empty;
    public HttpMethod Method { get; set; } = HttpMethod.GET;
    public string? Body { get; set; }
    public Dictionary<string, string> Headers { get; } = new();
    public Dictionary<string, string> QueryParameters { get; } = new();
    public int Timeout { get; set; } = 30;
    public bool RequiresAuthentication { get; set; } = false;

    public HttpRequestBuilder SetUrl(string url)
    {
        Url = url;
        return this;
    }
    public HttpRequestBuilder SetMethod(HttpMethod method)
    {
        Method = method;
        return this;
    }
    public HttpRequestBuilder SetBody(string body)
    {
        Body = body;
        return this;
    }
    public HttpRequestBuilder AddHeader(string key, string value)
    {
        Headers[key] = value;
        return this;
    }
    public HttpRequestBuilder AddQueryParameter(string key, string value)
    {
        QueryParameters[key] = value;
        return this;    
    }
    public HttpRequestBuilder SetTimeout(int timeout)
    {
        Timeout = timeout;
        return this;
    }
    public HttpRequestBuilder SetRequiresAuthentication(bool requiresAuthentication)
    {
        RequiresAuthentication = requiresAuthentication;
        return this;
    }

    public HttpRequest Build()
    {
        if(string.IsNullOrEmpty(Url))
            throw new InvalidOperationException("URL cannot be null or empty.");

        if((Method == HttpMethod.POST || Method == HttpMethod.PUT) && string.IsNullOrEmpty(Body))
            throw new InvalidOperationException("Body cannot be null or empty for POST or PUT requests.");

        if(Timeout <= 0)
            throw new InvalidOperationException("Timeout must be a positive integer.");

        if (Headers.ContainsKey("Authorization") != RequiresAuthentication)
            throw new InvalidOperationException(RequiresAuthentication
                ? "Authorization header must be set when authentication is required."
                : "Authorization header must not be set when authentication is not required.");

        if(Method == HttpMethod.GET && !string.IsNullOrEmpty(Body))
            throw new InvalidOperationException("Body must be null or empty for GET requests.");

        return new HttpRequest(
            Url,
            Method,
            Body,
            Headers,
            QueryParameters,
            Timeout,
            RequiresAuthentication);
    }
}