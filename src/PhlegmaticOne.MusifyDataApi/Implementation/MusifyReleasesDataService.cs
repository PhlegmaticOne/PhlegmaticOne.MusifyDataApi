using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Implementation;

internal class MusifyReleasesDataService : IMusifyReleasesDataService
{
    public Task<OperationResult<ReleaseInfoDto>> GetAlbumInfoAsync(string url)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<ReleaseDataDto<TrackInfoDto>>> GetAlbumWithTracksInfoAsync(string url)
    {
        throw new NotImplementedException();
    }
}
