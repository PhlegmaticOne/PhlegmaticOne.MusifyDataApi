using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Implementation;

internal class MusifyDownloadDataService : IMusifyDownloadDataService
{
    public event EventHandler<TrackDataDto>? TrackDownloaded;

    public Task<OperationResult<TrackDataDto>> DownloadTrack(string url)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<ReleaseDataDto<TrackDataDto>>> GetAlbumWithDownloadedTracksAsync(string url)
    {
        throw new NotImplementedException();
    }
}
