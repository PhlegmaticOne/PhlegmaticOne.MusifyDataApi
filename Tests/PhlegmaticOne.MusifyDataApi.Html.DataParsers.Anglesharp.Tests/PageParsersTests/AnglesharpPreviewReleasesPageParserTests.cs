using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.PageParsersTests;

public class AnglesharpPreviewReleasesPageParserTests
{
    private readonly string _url = "https://musify.club/artist/paysage-dhiver-31910/releases";
    private readonly AnglesharpPreviewReleasesPageParser _anglesharpPreviewReleasesPageParser;
    public AnglesharpPreviewReleasesPageParserTests()
    {
        var clientMock = HttpClientFactoryMock.ClientMock();
        var htmlStringGetter = new HttpClientHtmlStringGetter(clientMock);
        _anglesharpPreviewReleasesPageParser = new(htmlStringGetter);
    }

    [Fact]
    public async Task GetReleaseHtmlItems_Test()
    {
        await _anglesharpPreviewReleasesPageParser.ParsePageAsync(_url);

        var releaseItems = _anglesharpPreviewReleasesPageParser.GetReleaseHtmlItems();

        Assert.Equal(20, releaseItems.Count());
    }
}