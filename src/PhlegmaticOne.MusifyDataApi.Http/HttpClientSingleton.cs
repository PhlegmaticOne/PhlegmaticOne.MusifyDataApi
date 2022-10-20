using System.ComponentModel;

namespace PhlegmaticOne.MusifyDataApi.Http;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public class HttpClientSingleton
{
    private static readonly Lazy<HttpClient> _lazy = new(() =>
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(15);
        return client;
    }, true);
    private HttpClientSingleton() { }
    public static HttpClient Instance => _lazy.Value;
}