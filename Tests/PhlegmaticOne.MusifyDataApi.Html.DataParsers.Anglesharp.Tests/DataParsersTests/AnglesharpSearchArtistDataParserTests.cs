using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.DataParsersTests;

public class AnglesharpSearchArtistDataParserTests
{
    private readonly AnglesharpSearchArtistDataParser _anglesharpSearchArtistDataParser;
    public AnglesharpSearchArtistDataParserTests()
    {
        var musifyDataDownloadServiceMock = InterfacesMocks.GetMusifyDataDownloadServiceMock();
        _anglesharpSearchArtistDataParser = new(musifyDataDownloadServiceMock);
    }

    [Fact]
    public async Task GetAllInfoTests_Test()
    {
        var searchElement = HtmlItemsMocks.GetSearchArtistMockObject();

        _anglesharpSearchArtistDataParser.InitializeFromHtmlElement(searchElement);

        var cover = await _anglesharpSearchArtistDataParser.GetCoverAsync(true);
        var name = _anglesharpSearchArtistDataParser.GetName();
        var tracksCount = _anglesharpSearchArtistDataParser.GetTracksCount();
        var url = _anglesharpSearchArtistDataParser.GetUrl();

        Assert.NotEmpty(cover);
        Assert.Equal("Paysage D'Hiver", name);
        Assert.Equal(80, tracksCount);
        Assert.Equal("https://musify.club/artist/paysage-dhiver-31910", url);
    }
}