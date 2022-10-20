using Moq;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Implementation.Parsers.Tests.Mocks;

namespace PhlegmaticOne.MusifyDataApi.Implementation.Parsers.Tests;

public class MusifyArtistsDataServiceTests
{
    private readonly string _url = "https://musify.club/artist/paysage-dhiver-31910";
    private readonly MusifyArtistsDataService _musifyArtistsDataService;
    public MusifyArtistsDataServiceTests()
    {
        var artistParserMock = ParsersMocksCollection
            .GetArtistPageParserMock("Name", "Country", 100, 10);

        var artistPreviewReleasesPageParserMock = ParsersMocksCollection
            .GetArtistPreviewReleasesPageParserMock(5);

        var previewReleaseDataParser = ParsersMocksCollection
            .GetPreviewReleaseDataParser("Title", 2000, "url", 10,
                new List<string>() { "Artist" }, new List<string>() { "Genre" });

        var htmlParsersFactoryMock = new Mock<IHtmlParsersAbstractFactory>();

        ParsersMocksCollection
            .SetupHtmlParsersFactoryWithPageParser(htmlParsersFactoryMock, artistPreviewReleasesPageParserMock);
        ParsersMocksCollection
            .SetupHtmlParsersFactoryWithPageParser(htmlParsersFactoryMock, artistParserMock);
        ParsersMocksCollection
            .SetupHtmlParsersFactoryWithDataParser(htmlParsersFactoryMock, previewReleaseDataParser);


        _musifyArtistsDataService = new MusifyArtistsDataService(htmlParsersFactoryMock.Object);
    }

    [Fact]
    public async Task GetArtistInfoAsync_Test()
    {
        var result = await _musifyArtistsDataService
            .GetArtistInfoAsync(_url);
        var artist = result.Data!;

        Assert.Equal("Country", artist.Country);
        Assert.Equal("Name", artist.Name);
        Assert.Equal(_url, artist.Url);
        Assert.Equal(100, artist.TracksCount);
        Assert.Equal(10, artist.CoverData.Length);
    }

    [Fact]
    public async Task GetArtistInfoWithReleasesAsync_Test()
    {
        var result = await _musifyArtistsDataService
            .GetArtistWithReleasesAsync(_url);
        var artist = result.Data!;

        Assert.Equal("Country", artist.Country);
        Assert.Equal("Name", artist.Name);
        Assert.Equal(_url, artist.Url);
        Assert.Equal(100, artist.TracksCount);
        Assert.Equal(10, artist.CoverData.Length);
        Assert.Equal(5, artist.Releases.Count);

        Assert.All(artist.Releases, r =>
        {
            Assert.Equal("url", r.Url);
            Assert.Equal("Title", r.Title);
            Assert.Equal(2000, r.YearReleased.YearReleased);
            Assert.Equal("Name", r.ArtistName);
            Assert.Equal(10, r.CoverData.Length);
            Assert.Collection(r.Genres, g => Assert.Equal("Genre", g.Name));
        });
    }
}