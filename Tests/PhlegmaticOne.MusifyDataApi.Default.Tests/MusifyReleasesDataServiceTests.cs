using Moq;
using PhlegmaticOne.MusifyDataApi.Default.Tests.Mocks;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Implementation.Parsers;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.Default.Tests;

public class MusifyReleasesDataServiceTests
{
    private readonly MusifyReleasesDataService _musifyReleasesDataService;

    public MusifyReleasesDataServiceTests()
    {
        var releasePageParser = ParsersMocksCollection
            .GetReleasePageParser("Title", MusifyReleaseType.LP, 2000, 10,
                new List<string> { "Genre1", "Genre2" },
                new List<(string, string)> { ("Track1", "Artist1"), ("Track2", "Artist2") });

        var htmlParsersFactoryMock = new Mock<IHtmlParsersAbstractFactory>();
        ParsersMocksCollection
            .SetupHtmlParsersFactoryWithPageParser(htmlParsersFactoryMock, releasePageParser);

        _musifyReleasesDataService = new MusifyReleasesDataService(htmlParsersFactoryMock.Object);
    }

    [Fact]
    public async Task GetReleaseInfoAsync_Test()
    {
        var result = await _musifyReleasesDataService.GetReleaseInfoAsync("");
        var release = result!.Data!;

        Assert.Equal("Title", release.Title);
        Assert.Equal(MusifyReleaseType.LP, release.ReleaseType);
        Assert.Equal(2000, release.YearReleased.YearReleased);
        Assert.Equal(10, release.CoverData.Length);
    }

    [Fact]
    public async Task GetReleaseWithTracksInfoAsync_Test()
    {
        var result = await _musifyReleasesDataService.GetReleaseWithTracksInfoAsync("");
        var release = result!.Data!;

        Assert.Equal("Title", release.Title);
        Assert.Equal(MusifyReleaseType.LP, release.ReleaseType);
        Assert.Equal(2000, release.YearReleased.YearReleased);
        Assert.Equal(10, release.CoverData.Length);
        Assert.Collection(release.Genres, 
            g => Assert.Equal("Genre1", g.Name),
            g => Assert.Equal("Genre2", g.Name));
        Assert.Collection(release.Tracks,
            g => Assert.Equal("Track1", g.Title),
            g => Assert.Equal("Track2", g.Title));
        Assert.Collection(release.Artists,
            a => Assert.Equal("Artist1", a.Name),
            a => Assert.Equal("Artist2", a.Name));
    }
}