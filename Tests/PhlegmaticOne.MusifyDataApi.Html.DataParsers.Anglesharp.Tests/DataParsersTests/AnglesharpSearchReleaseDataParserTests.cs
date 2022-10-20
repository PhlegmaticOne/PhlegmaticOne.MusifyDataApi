using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.DataParsersTests;

public class AnglesharpSearchReleaseDataParserTests
{
    private readonly AnglesharpSearchReleaseDataParser _anglesharpSearchArtistDataParser;
    public AnglesharpSearchReleaseDataParserTests()
    {
        var musifyDataDownloadServiceMock = InterfacesMocks.GetMusifyDataDownloadServiceMock();
        _anglesharpSearchArtistDataParser = new(musifyDataDownloadServiceMock);
    }

    [Fact]
    public async Task GetAllInfoTests_Test()
    {
        var searchElement = HtmlItemsMocks.GetSearchReleaseMockObject();

        _anglesharpSearchArtistDataParser.InitializeFromHtmlElement(searchElement);

        var cover = await _anglesharpSearchArtistDataParser.GetCoverAsync(true);
        var title = _anglesharpSearchArtistDataParser.GetTitle();
        var tracksCount = _anglesharpSearchArtistDataParser.GetTracksCount();
        var url = _anglesharpSearchArtistDataParser.GetUrl();
        var year = _anglesharpSearchArtistDataParser.GetYear();
        var artistName = _anglesharpSearchArtistDataParser.GetArtistName();

        Assert.NotEmpty(cover);
        Assert.Equal("Paysage D'Hiver", artistName);
        Assert.Equal("Winterkaelte", title);
        Assert.Equal(6, tracksCount);
        Assert.Equal(2001, year.YearReleased);
        Assert.Equal("https://musify.club/release/paysage-dhiver-winterkaelte-2001-52893", url);
    }
}