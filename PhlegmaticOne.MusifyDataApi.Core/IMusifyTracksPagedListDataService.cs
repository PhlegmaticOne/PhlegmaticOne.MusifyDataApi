using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Categories;
using PhlegmaticOne.MusifyDataApi.Models.PagedList;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyTracksPagedListDataService
{
    Task<OperationResult<PagedListDto<TrackInfoDto>>> GetTracksPagedListAsync(int pageIndex,
        ISearchCategoryString searchCategoryString);
}
