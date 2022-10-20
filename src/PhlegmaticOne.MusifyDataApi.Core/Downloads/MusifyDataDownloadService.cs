using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.DataDownload.Core;

namespace PhlegmaticOne.MusifyDataApi.Core.Downloads;

public class MusifyDataDownloadService : IMusifyDataDownloadService
{
    private readonly IDataDownloadService _dataDownloadService;

    public MusifyDataDownloadService(IDataDownloadService dataDownloadService) =>
        _dataDownloadService = dataDownloadService;

    public async Task<byte[]> DownloadAsync(string url)
    {
        var musifyUrl = url.AsMusifyUrl();
        var data = await _dataDownloadService.DownloadAsync(musifyUrl.ToStringUrl());
        return data;
    }
}