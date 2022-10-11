using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyDownloadDataService
{
    event EventHandler<TrackDataDto>? TrackDownloaded;
    Task<OperationResult<ReleaseDataDto<TrackDataDto>>> GetAlbumWithDownloadedTracksAsync(string url);
    Task<OperationResult<TrackDataDto>> DownloadTrack(string url);
}
