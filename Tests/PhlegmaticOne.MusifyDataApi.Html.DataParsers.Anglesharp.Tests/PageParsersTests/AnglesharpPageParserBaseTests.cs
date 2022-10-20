using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Http;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.PageParsersTests;

public class AnglesharpPageParserBaseTests
{
    private readonly AnglesharpPageParserBase _anglesharpPageParserBase;
    public AnglesharpPageParserBaseTests()
    {
        var htmlStringGetter = new HttpClientHtmlStringGetter();
        var musifyDataDownloadService = InterfacesMocks.GetMusifyDataDownloadServiceMock();

        _anglesharpPageParserBase = new AnglesharpArtistPageParser(htmlStringGetter, musifyDataDownloadService);
    }

    [Fact]
    public async Task ParsePage_ShouldThrowException_InvalidUrl_Test()
    {
        const string url = "https://musify.club/artist/payaoweuthbaw";

        await Assert.ThrowsAsync<HttpRequestException>(async () =>
            await _anglesharpPageParserBase.ParsePageAsync(url));
    }

    [Fact]
    public async Task ParsePage_ShouldBeSuccessful_InvalidUrl_Test()
    {
        const string url = "https://musify.club/artist/paysage-dhiver-31910";

        await _anglesharpPageParserBase.ParsePageAsync(url);
    }
}