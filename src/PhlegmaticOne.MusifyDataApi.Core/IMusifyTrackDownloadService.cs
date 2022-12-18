using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;
using PhlegmaticOne.OperationResults;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyTrackDownloadService
{
    Task<OperationResult<TrackDataDto>> DownloadTrackAsync(TrackInfoDto trackDto);
}
