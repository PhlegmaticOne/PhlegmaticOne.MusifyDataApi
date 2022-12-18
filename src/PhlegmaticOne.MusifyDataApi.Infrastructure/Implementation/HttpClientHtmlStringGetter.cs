using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;

public class HttpClientHtmlStringGetter : IHtmlStringGetter
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientHtmlStringGetter(IHttpClientFactory httpClientFactory) => 
        _httpClientFactory = httpClientFactory;

    public Task<string> GetHtmlStringAsync(string url)
    {
        var client = _httpClientFactory.CreateClient(HttpClientConstants.ServerName);
        return client.GetStringAsync(url);
    }
}