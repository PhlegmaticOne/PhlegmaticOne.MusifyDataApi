using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Models.Categories;
using PhlegmaticOne.MusifyDataApi.Models.PagedList;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Default;

public class MusifyReleasesPagedListDataService : IMusifyReleasesPagedListDataService
{
    public Task<PagedListDto<ReleasePreviewDtoBase>> GetPreviewPagedListAsync(int pageIndex, ISearchCategoryString searchCategoryString, bool includeCovers = false)
    {
        throw new NotImplementedException();
    }

    public Task<PagedListDto<ReleaseFullPreviewDto>> GetFullPreviewPagedListAsync(int pageIndex, ISearchCategoryString searchCategoryString,
        bool includeCovers = false)
    {
        throw new NotImplementedException();
    }
}
