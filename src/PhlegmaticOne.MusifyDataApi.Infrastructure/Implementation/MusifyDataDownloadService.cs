using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;

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