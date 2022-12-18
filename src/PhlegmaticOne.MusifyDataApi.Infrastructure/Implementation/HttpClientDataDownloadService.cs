using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;

public class HttpClientDataDownloadService : IDataDownloadService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientDataDownloadService(IHttpClientFactory httpClientFactory) => 
        _httpClientFactory = httpClientFactory;

    public Task<byte[]> DownloadAsync(string downloadUrl)
    {
        var client = _httpClientFactory.CreateClient(HttpClientConstants.ServerName);
        return client.GetByteArrayAsync(downloadUrl);
    }
}