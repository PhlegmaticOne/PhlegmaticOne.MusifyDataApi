using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;
using PhlegmaticOne.OperationResults;

namespace PhlegmaticOne.MusifyDataApi.Implementation.Parsers;

public class MusifyTrackDownloadService : IMusifyTrackDownloadService, IUseHtmlParsers
{
    private readonly IMusifyDataDownloadService _dataDownloadService;

    public MusifyTrackDownloadService(IMusifyDataDownloadService dataDownloadService) =>
        _dataDownloadService = dataDownloadService;

    public async Task<OperationResult<TrackDataDto>> DownloadTrackAsync(TrackInfoDto trackDto) =>
        await OperationResult.FromActionResult(() => DownloadTrackAsyncPrivate(trackDto));

    private async Task<TrackDataDto> DownloadTrackAsyncPrivate(TrackInfoDto trackDto)
    {
        var data = await _dataDownloadService.DownloadAsync(trackDto.DownloadUrl);
        return new()
        {
            Artists = trackDto.Artists,
            DownloadUrl = trackDto.DownloadUrl,
            Duration = trackDto.Duration,
            Title = trackDto.Title,
            TrackData = data,
            Url = trackDto.Url
        };
    }
}
