using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.DataParsersTests;

public class AnglesharpPreviewReleaseParserTests
{
    private readonly AnglesharpPreviewReleaseDataParser _anglesharpPreviewReleaseDataParser;
    public AnglesharpPreviewReleaseParserTests()
    {
        var musifyDataDownloadServiceMock = InterfacesMocks.GetMusifyDataDownloadServiceMock();
        _anglesharpPreviewReleaseDataParser = new(musifyDataDownloadServiceMock);
    }

    [Fact]
    public async Task GetAllInfoTests_Test()
    {
        var previewReleaseMock = HtmlItemsMocks.GetPreviewReleaseMockObject();

        _anglesharpPreviewReleaseDataParser.InitializeFromHtmlElement(previewReleaseMock);

        var cover = await _anglesharpPreviewReleaseDataParser.GetCoverAsync(true);
        var genres = _anglesharpPreviewReleaseDataParser.GetGenres();
        var artists = _anglesharpPreviewReleaseDataParser.GetArtists();
        var title = _anglesharpPreviewReleaseDataParser.GetTitle();
        var year = _anglesharpPreviewReleaseDataParser.GetYear();
        var url = _anglesharpPreviewReleaseDataParser.GetUrl();

        Assert.NotEmpty(cover);
        Assert.Collection(genres,
            g => Assert.Equal("Classic Rock", g.Name),
            g => Assert.Equal("Progressive Rock", g.Name),
            g => Assert.Equal("Art Rock", g.Name));
        Assert.Collection(artists, a => Assert.Equal("Pink Floyd", a.Name));
        Assert.Equal("Wish You Were Here", title);
        Assert.Equal(1975, year.YearReleased);
        Assert.Equal("https://musify.club/release/pink-floyd-wish-you-were-here-1975-4863", url);
    }
}