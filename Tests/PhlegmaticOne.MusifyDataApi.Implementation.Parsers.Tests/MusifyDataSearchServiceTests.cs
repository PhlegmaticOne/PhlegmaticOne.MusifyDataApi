using Moq;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Implementation.Parsers.Tests.Mocks;

namespace PhlegmaticOne.MusifyDataApi.Implementation.Parsers.Tests;

public class MusifyDataSearchServiceTests
{
    private readonly MusifyDataSearchService _musifyDataSearchService;

    public MusifyDataSearchServiceTests()
    {
        var searchPageParser = ParsersMocksCollection
            .GetSearchPageParser(5, 5);
        var searchReleaseDataParser = ParsersMocksCollection
            .GetSearchReleaseDataParser("Title", "Name", "Url", 100, 2000, 10);
        var searchArtistDataParser = ParsersMocksCollection
            .GetSearchArtistDataParser("Name", 100, "Url", 10);

        var htmlParsersFactoryMock = new Mock<IHtmlParsersAbstractFactory>();
        ParsersMocksCollection
            .SetupHtmlParsersFactoryWithPageParser(htmlParsersFactoryMock, searchPageParser);
        ParsersMocksCollection
            .SetupHtmlParsersFactoryWithDataParser(htmlParsersFactoryMock, searchReleaseDataParser);
        ParsersMocksCollection
            .SetupHtmlParsersFactoryWithDataParser(htmlParsersFactoryMock, searchArtistDataParser);

        _musifyDataSearchService = new MusifyDataSearchService(htmlParsersFactoryMock.Object);
    }

    [Fact]
    public async Task SearchArtistsAsync_Test()
    {
        var searchText = "paysage";

        var result = await _musifyDataSearchService.SearchArtistsAsync(searchText);

        var artists = result!.Result!.Items;

        Assert.Equal(5, artists.Count);

        Assert.All(artists, a =>
        {
            Assert.Equal("Name", a.Name);
            Assert.Equal(100, a.TracksCount);
            Assert.Equal("Url", a.Url);
            Assert.Equal(10, a.CoverData.Length);
        });
    }

    [Fact]
    public async Task SearchReleasesAsync_Test()
    {
        var searchText = "paysage";

        var result = await _musifyDataSearchService.SearchReleasesAsync(searchText);

        var releases = result!.Result!.Items;

        Assert.Equal(5, releases.Count);

        Assert.All(releases, a =>
        {
            Assert.Equal("Title", a.Title);
            Assert.Equal(100, a.TracksCount);
            Assert.Equal("Url", a.Url);
            Assert.Equal(10, a.CoverData.Length);
            Assert.Equal(2000, a.YearReleased.YearReleased);
            Assert.Equal("Name", a.ArtistName);
        });
    }
}