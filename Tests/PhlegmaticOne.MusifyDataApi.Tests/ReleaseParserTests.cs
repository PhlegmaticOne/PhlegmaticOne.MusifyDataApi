using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class ReleaseParserTests
{
    private readonly IReleasePageParser _releaseDataParser;
    private readonly string _releaseUrl = "https://musify.club/release/vinterriket-and-paysage-dhiver-2003-205226";

    public ReleaseParserTests()
    {
        _releaseDataParser = new AnglesharpReleasePageParser();
    }
    [Fact]
    public async Task GetTitle_Test()
    {
        await _releaseDataParser.ParsePageAsync(_releaseUrl);
        var title = _releaseDataParser.GetTitle();
        Assert.Equal("Vinterriket & Paysage D'Hiver", title);
    }

    [Fact]
    public async Task GetGenres_Test()
    {
        await _releaseDataParser.ParsePageAsync(_releaseUrl);
        var genres = _releaseDataParser.GetGenres();
        Assert.Collection(genres, g => Assert.Equal("Ambient Black", g.Name));
    }

    [Fact]
    public async Task GetCover_Test()
    {
        await _releaseDataParser.ParsePageAsync(_releaseUrl);
        var cover = await _releaseDataParser.GetReleaseCoverAsync(true);
        Assert.NotEmpty(cover);
    }

    [Fact]
    public async Task GetReleaseType_Test()
    {
        await _releaseDataParser.ParsePageAsync(_releaseUrl);
        var releaseType = _releaseDataParser.GetReleaseType();
        Assert.Equal(MusifyReleaseType.Split, releaseType);
    }

    [Fact]
    public async Task GetTracks_Test()
    {
        await _releaseDataParser.ParsePageAsync(_releaseUrl);
        var tracks = _releaseDataParser.GetTracks();

        Assert.Collection(tracks, 
            t => AssertionHelpers.TrackAssert(t, "Schnee", "Paysage D'Hiver"),
            t => AssertionHelpers.TrackAssert(t, "Das Winterreich", "Vinterriket"));
    }
}