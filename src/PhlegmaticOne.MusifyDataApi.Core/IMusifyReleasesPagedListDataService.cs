using PhlegmaticOne.MusifyDataApi.Models.Categories.Categories;
using PhlegmaticOne.MusifyDataApi.Models.PagedList;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyReleasesPagedListDataService
{
    Task<PagedListDto<ReleaseFullPreviewDto>> GetPreviewPagedListAsync(int pageIndex,
        ISearchCategoryString searchCategoryString,
        bool includeCovers = false);
}