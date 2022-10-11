using PhlegmaticOne.MusifyDataApi.Categories;
using PhlegmaticOne.MusifyDataApi.Dtos.PagedList;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyReleasesPagedListDataService
{
    Task<PagedListDto<ReleasePreviewDtoBase>> GetPreviewPagedList(int pageIndex,
        ISearchCategoryString searchCategoryString,
        bool includeCovers = false);
    Task<PagedListDto<ReleaseFullPreviewDto>> GetFullPreviewPagedList(int pageIndex,
        ISearchCategoryString searchCategoryString,
        bool includeCovers = false);
    Task<PagedListDto<ReleaseFullInfoDto>> GetFullInfoPreviewPagedList(int pageIndex,
        ISearchCategoryString searchCategoryString,
        bool includeCovers = false);
}