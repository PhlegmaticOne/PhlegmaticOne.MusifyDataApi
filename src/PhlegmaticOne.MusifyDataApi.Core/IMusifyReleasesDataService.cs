using PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;
using PhlegmaticOne.OperationResults;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyReleasesDataService
{
    Task<OperationResult<ReleaseInfoDto>> GetReleaseInfoAsync(string url, bool includeCover = false);
    Task<OperationResult<ReleaseDataDto<TrackInfoDto>>> GetReleaseWithTracksInfoAsync(string url, bool includeCover = false);
}