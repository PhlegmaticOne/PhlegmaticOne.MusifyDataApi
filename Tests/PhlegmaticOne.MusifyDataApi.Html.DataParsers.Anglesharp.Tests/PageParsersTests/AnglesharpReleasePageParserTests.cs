using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Http;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.PageParsersTests;

public class AnglesharpReleasePageParserTests
{
    private readonly string _url = "https://musify.club/release/vinterriket-and-paysage-dhiver-2003-205226";
    private readonly AnglesharpReleasePageParser _anglesharpReleasePageParser;
    public AnglesharpReleasePageParserTests()
    {
        var htmlStringGetter = new HttpClientHtmlStringGetter();
        var musifyDataDownloadService = InterfacesMocks.GetMusifyDataDownloadServiceMock();

        _anglesharpReleasePageParser = new(htmlStringGetter, musifyDataDownloadService);
    }

    [Fact]
    public async Task GetAllInfo_Test()
    {
        await _anglesharpReleasePageParser.ParsePageAsync(_url);

        var title = _anglesharpReleasePageParser.GetTitle();
        var year = _anglesharpReleasePageParser.GetYear();
        var releaseType = _anglesharpReleasePageParser.GetReleaseType();
        var genres = _anglesharpReleasePageParser.GetGenres();
        var cover = await _anglesharpReleasePageParser.GetReleaseCoverAsync(true);
        var tracks = _anglesharpReleasePageParser.GetTracks();

        Assert.Equal("Vinterriket & Paysage D'Hiver", title);
        Assert.Equal(2003, year.YearReleased);
        Assert.Equal(MusifyReleaseType.Split, releaseType);
        Assert.Collection(genres, g => Assert.Equal("Ambient Black", g.Name));
        Assert.NotEmpty(cover);
        Assert.Collection(tracks, t =>
        {
            Assert.Equal("Schnee", t.Title);
            Assert.Collection(t.Artists, a => Assert.Equal("Paysage D'Hiver", a.Name));
        }, t =>
        {
            Assert.Equal("Das Winterreich", t.Title);
            Assert.Collection(t.Artists, a => Assert.Equal("Vinterriket", a.Name));
        });
    }
}