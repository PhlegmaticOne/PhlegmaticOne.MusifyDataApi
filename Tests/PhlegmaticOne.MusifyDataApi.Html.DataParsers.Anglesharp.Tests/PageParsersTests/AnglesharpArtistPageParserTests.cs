using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.PageParsersTests;

public class AnglesharpArtistPageParserTests
{
    private readonly string _url = "https://musify.club/artist/paysage-dhiver-31910";
    private readonly AnglesharpArtistPageParser _anglesharpArtistPageParser;
    public AnglesharpArtistPageParserTests()
    {
        var clientMock = HttpClientFactoryMock.ClientMock();
        var htmlStringGetter = new HttpClientHtmlStringGetter(clientMock);
        var musifyDataDownloadServiceMock = InterfacesMocks.GetMusifyDataDownloadServiceMock();
        _anglesharpArtistPageParser = new AnglesharpArtistPageParser(htmlStringGetter, musifyDataDownloadServiceMock);
    }

    [Fact]
    public async Task GetAllInfo_Test()
    {
        await _anglesharpArtistPageParser.ParsePageAsync(_url);
        var country = _anglesharpArtistPageParser.GetCountry();
        var cover = await _anglesharpArtistPageParser.GetCoverAsync(true);
        var name = _anglesharpArtistPageParser.GetName();
        var tracksCount = _anglesharpArtistPageParser.GetTracksCount();

        Assert.Equal(80, tracksCount);
        Assert.Equal("Paysage D'Hiver", name);
        Assert.NotEmpty(cover);
        Assert.Equal("Швейцария", country);
    }
}