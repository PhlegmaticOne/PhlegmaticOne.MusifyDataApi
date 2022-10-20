using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Http;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.PageParsersTests;

public class AnglesharpSearchPageParserTests
{
    private readonly string _url = "https://musify.club/search?searchText=night";
    private readonly AnglesharpSearchPageParser _anglesharpSearchPageParser;
    public AnglesharpSearchPageParserTests()
    {
        var htmlStringGetter = new HttpClientHtmlStringGetter();
        _anglesharpSearchPageParser = new(htmlStringGetter);
    }

    [Fact]
    public async Task GetArtistHtmlItems_Default_Test()
    {
        await _anglesharpSearchPageParser.ParsePageAsync(_url);

        var artistsElements = _anglesharpSearchPageParser.GetArtistHtmlItems();

        Assert.Equal(5, artistsElements.Count());
    }

    [Fact]
    public async Task GetArtistHtmlItems_Test()
    {
        await _anglesharpSearchPageParser.ParsePageAsync(_url);
        const int countToSelect = 2;

        var artistsElements = _anglesharpSearchPageParser.GetArtistHtmlItems(countToSelect);

        Assert.Equal(countToSelect, artistsElements.Count());
    }

    [Fact]
    public async Task GetReleaseHtmlItems_Default_Test()
    {
        await _anglesharpSearchPageParser.ParsePageAsync(_url);

        var releaseElements = _anglesharpSearchPageParser.GetReleaseHtmlItems();

        Assert.Equal(20, releaseElements.Count());
    }

    [Fact]
    public async Task GetReleaseHtmlItems_Test()
    {
        await _anglesharpSearchPageParser.ParsePageAsync(_url);
        const int countToSelect = 2;

        var artistsElements = _anglesharpSearchPageParser.GetArtistHtmlItems(countToSelect);

        Assert.Equal(countToSelect, artistsElements.Count());
    }
}