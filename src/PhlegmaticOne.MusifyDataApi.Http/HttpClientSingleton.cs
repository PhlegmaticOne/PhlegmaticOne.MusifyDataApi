namespace PhlegmaticOne.MusifyDataApi.Http;

public class HttpClientSingleton
{
    private static readonly Lazy<HttpClient> _lazy = new(() => new(), true);
    private HttpClientSingleton() { }
    public static HttpClient Instance => _lazy.Value;
}