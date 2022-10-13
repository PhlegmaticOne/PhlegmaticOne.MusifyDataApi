using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class SearchTests
{
    private readonly ISearchPageParser _searchPageParser;
    private readonly string _searchUrl = "http://musify.club/search?searchText=paysage";

    public SearchTests()
    {
        _searchPageParser = new AnglesharpSearchPageParser();
    }

    [Fact]
    public async Task Search()
    {
        await _searchPageParser.ParsePageAsync(_searchUrl);

        var items = _searchPageParser.GetArtistHtmlItems();

        Assert.NotNull(items);
    }
}
