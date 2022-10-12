using PhlegmaticOne.MusifyDataApi.Models.Categories;
using PhlegmaticOne.MusifyDataApi.Models.PagedList;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyReleasesPagedListDataService
{
    Task<PagedListDto<ReleasePreviewDtoBase>> GetPreviewPagedListAsync(int pageIndex,
        ISearchCategoryString searchCategoryString,
        bool includeCovers = false);
    Task<PagedListDto<ReleaseFullPreviewDto>> GetFullPreviewPagedListAsync(int pageIndex,
        ISearchCategoryString searchCategoryString,
        bool includeCovers = false);
}