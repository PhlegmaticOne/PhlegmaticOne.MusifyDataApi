using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Downloads;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Default;

public class MusifyTrackDownloadService : IMusifyTrackDownloadService
{
    private readonly IMusifyDataDownloadService _dataDownloadService;

    public MusifyTrackDownloadService(IMusifyDataDownloadService dataDownloadService) => 
        _dataDownloadService = dataDownloadService;

    public async Task<OperationResult<TrackDataDto>> DownloadTrackAsync(TrackInfoDto trackDto) =>
        await OperationResult<TrackDataDto>.FromActionResult(() => DownloadTrackAsyncPrivate(trackDto));

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
