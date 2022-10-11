using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyReleasesDataService
{
    Task<OperationResult<ReleaseInfoDto>> GetAlbumInfoAsync(string url);
    Task<OperationResult<ReleaseDataDto<TrackInfoDto>>> GetAlbumWithTracksInfoAsync(string url);
}