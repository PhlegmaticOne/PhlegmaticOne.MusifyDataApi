using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Categories;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Base;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyTracksPagedListDataService
{
    Task<OperationResult<TrackDtoBase>> GetTracks(int pageIndex,
        ISearchCategoryString searchCategoryString);
    Task<OperationResult<TrackInfoDto>> GetTracksInfo(int pageIndex,
        ISearchCategoryString searchCategoryString);
}
