using PhlegmaticOne.MusifyDataApi.DataDownload.Core;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusifyDataApi.DataDownload.Http;

public class HttpClientDataDownloadService : IDataDownloadService
{
    public async Task<byte[]> DownloadAsync(string downloadUrl) =>
        await HttpClientSingleton.Instance.GetByteArrayAsync(downloadUrl);
}