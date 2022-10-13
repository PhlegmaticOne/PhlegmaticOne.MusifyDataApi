using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.DataDownload.Core;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Default;

public class MusifyTrackDownloadService : IMusifyTrackDownloadService
{
    private readonly IDataDownloadService _dataDownloadService;

    public MusifyTrackDownloadService(IDataDownloadService dataDownloadService) => 
        _dataDownloadService = dataDownloadService;

    public async Task<OperationResult<TrackDataDto>> DownloadTrackAsync(TrackInfoDto trackDto) =>
        await OperationResult<TrackDataDto>.FromActionResult(() => DownloadTrackAsyncPrivate(trackDto));

    private async Task<OperationResult<TrackDataDto>> DownloadTrackAsyncPrivate(TrackInfoDto trackDto)
    {
        var data = await _dataDownloadService.DownloadAsync(trackDto.DownloadUrl);
        return OperationResult<TrackDataDto>.FromSuccess(new()
        {
            Artists = trackDto.Artists,
            DownloadUrl = trackDto.DownloadUrl,
            Duration = trackDto.Duration,
            Title = trackDto.Title,
            TrackData = data,
            Url = trackDto.Url
        });
    }
}
