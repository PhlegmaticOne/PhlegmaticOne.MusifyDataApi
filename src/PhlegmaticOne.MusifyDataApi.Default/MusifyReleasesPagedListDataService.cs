using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Models.Categories;
using PhlegmaticOne.MusifyDataApi.Models.Categories.Categories;
using PhlegmaticOne.MusifyDataApi.Models.PagedList;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Default;

public class MusifyReleasesPagedListDataService : IMusifyReleasesPagedListDataService
{
    private readonly IHtmlParsersFactory _htmlParsersFactory;

    public MusifyReleasesPagedListDataService(IHtmlParsersFactory htmlParsersFactory)
    {
        _htmlParsersFactory = htmlParsersFactory;
    }

    public Task<PagedListDto<ReleaseFullPreviewDto>> GetPreviewPagedListAsync(int pageIndex,
        ISearchCategoryString searchCategoryString,
        bool includeCovers = false)
    {
        throw new NotImplementedException();
    }
}
