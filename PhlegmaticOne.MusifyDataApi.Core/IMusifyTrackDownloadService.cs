using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyTrackDownloadService
{
    Task<OperationResult<TrackDataDto>> DownloadTrackAsync(TrackInfoDto trackDto);
}
