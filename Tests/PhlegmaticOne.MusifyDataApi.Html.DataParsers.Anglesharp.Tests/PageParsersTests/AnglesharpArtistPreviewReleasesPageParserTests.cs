using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Http;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.PageParsersTests;

public class AnglesharpArtistPreviewReleasesPageParserTests
{
    private readonly string _url = "https://musify.club/artist/paysage-dhiver-31910/releases";
    private readonly AnglesharpArtistPreviewReleasesPageParser _anglesharpArtistPreviewReleasesPageParser;
    public AnglesharpArtistPreviewReleasesPageParserTests()
    {
        var htmlStringGetter = new HttpClientHtmlStringGetter();
        _anglesharpArtistPreviewReleasesPageParser = new(htmlStringGetter);
    }

    [Fact]
    public async Task GetReleaseHtmlItems_Default_Test()
    {
        await _anglesharpArtistPreviewReleasesPageParser.ParsePageAsync(_url);
        var htmlItems = _anglesharpArtistPreviewReleasesPageParser.GetReleaseHtmlItems();

        Assert.Equal(19, htmlItems.Count());
    }

    [Fact]
    public async Task GetReleaseHtmlItems_Include_Test()
    {
        var includeTypes = new List<MusifyReleaseType>
        {
            MusifyReleaseType.Demo,
            MusifyReleaseType.LP
        };

        await _anglesharpArtistPreviewReleasesPageParser.ParsePageAsync(_url);

        var htmlItems = _anglesharpArtistPreviewReleasesPageParser
            .GetReleaseHtmlItems(SelectionType.Include, includeTypes);

        Assert.Equal(12, htmlItems.Count());
    }

    [Fact]
    public async Task GetReleaseHtmlItems_Exclude_Test()
    {
        var excludeTypes = new List<MusifyReleaseType>
        {
            MusifyReleaseType.Demo,
            MusifyReleaseType.LP,
            MusifyReleaseType.ArtistsCompilation
        };

        await _anglesharpArtistPreviewReleasesPageParser.ParsePageAsync(_url);
        var htmlItems = _anglesharpArtistPreviewReleasesPageParser
            .GetReleaseHtmlItems(SelectionType.Exclude, excludeTypes);

        Assert.Equal(7, htmlItems.Count());
    }
}