using PhlegmaticOne.MusifyDataApi.Categories;
using PhlegmaticOne.MusifyDataApi.Dtos.PagedList;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Implementation;

internal class MusifyReleasesPagedListDataService : IMusifyReleasesPagedListDataService
{
    public Task<PagedListDto<ReleaseFullInfoDto>> GetFullInfoPreviewPagedList(int pageIndex, ISearchCategoryString searchCategoryString, bool includeCovers = false)
    {
        throw new NotImplementedException();
    }

    public Task<PagedListDto<ReleaseFullPreviewDto>> GetFullPreviewPagedList(int pageIndex, ISearchCategoryString searchCategoryString, bool includeCovers = false)
    {
        throw new NotImplementedException();
    }

    public Task<PagedListDto<ReleasePreviewDtoBase>> GetPreviewPagedList(int pageIndex, ISearchCategoryString searchCategoryString, bool includeCovers = false)
    {
        throw new NotImplementedException();
    }
}
