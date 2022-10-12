using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Default;

internal class MusifyDownloadDataService : IMusifyDownloadDataService
{
    public event EventHandler<TrackDataDto>? TrackDownloaded;

    public Task<OperationResult<TrackDataDto>> DownloadTrackAsync(string url)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<ReleaseDataDto<TrackDataDto>>> GetAlbumWithDownloadedTracksAsync(string url)
    {
        throw new NotImplementedException();
    }
}
