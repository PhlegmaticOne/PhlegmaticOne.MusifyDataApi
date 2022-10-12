using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Categories;
using PhlegmaticOne.MusifyDataApi.Models.PagedList;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Default;

internal class MusifyTracksPagedListDataService : IMusifyTracksPagedListDataService
{
    public Task<OperationResult<PagedListDto<TrackInfoDto>>> GetTracksPagedListAsync(int pageIndex, ISearchCategoryString searchCategoryString)
    {
        throw new NotImplementedException();
    }
}
