using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyDownloadDataService
{
    event EventHandler<TrackDataDto>? TrackDownloaded;
    Task<OperationResult<ReleaseDataDto<TrackDataDto>>> GetAlbumWithDownloadedTracksAsync(string url);
    Task<OperationResult<TrackDataDto>> DownloadTrackAsync(string url);
}
