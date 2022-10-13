using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Default;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class SearchDataTests
{
    private readonly IMusifyDataSearchService _musifyDataSearchService;
    private readonly string _search = "aslflksaldfwe";

    public SearchDataTests()
    {
        var parsersConfiguration = new CommonHtmlParsersFactoryConfiguration(typeof(AnglesharpReleasePageParser).Assembly);
        var parsersFactory = new CommonHtmlParsersFactory(parsersConfiguration);
        _musifyDataSearchService = new MusifyDataSearchService(parsersFactory);
    }

    [Fact]
    public async Task SearchReleases_Test()
    {
        var result = await _musifyDataSearchService.SearchReleasesAsync(_search, 4, true);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task SearchArtists_Test()
    {
        var result = await _musifyDataSearchService.SearchArtistsAsync(_search, 4, true);
        Assert.NotNull(result);
    }
}
