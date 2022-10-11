using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusifyDataApi.Extensions;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class MusifyReleasesDataTests
{
    private readonly IMusifyReleasesDataService _musifyTracksData;
    public MusifyReleasesDataTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMusifyDataApi();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _musifyTracksData = serviceProvider.GetRequiredService<IMusifyReleasesDataService>();
    }
    [Fact]
    public async Task GetAlbumInfoAsync_ShouldBeNotSuccess_Test()
    {
        var url = "https://musify.club/release/not-existing-release";
        var result = await _musifyTracksData.GetAlbumInfoAsync(url);

        Assert.False(result.IsOk);
        Assert.NotNull(result.ExceptionThrowed);
        Assert.IsAssignableFrom<HttpRequestException>(result.ExceptionThrowed);
        Assert.Null(result.Data);
    }

    [Fact]
    public async Task GetAlbumInfoAsync_ShouldBeNotNull_Test()
    {
        var url = "https://musify.club/release/assassination-circles-within-circles-2019-1225489";
        var result = await _musifyTracksData.GetAlbumInfoAsync(url);

        Assert.True(result.IsOk);
        Assert.Null(result.ExceptionThrowed);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task GetAlbumInfoAsync_ShouldBeExpectedAlbumData_Test()
    {
        var url = "https://musify.club/release/assassination-circles-within-circles-2019-1225489";
        var result = await _musifyTracksData.GetAlbumInfoAsync(url);
        var data = result.Data!;

        AssertionHelpers.AlbumAssert(data, "Circles Within Circles", MusifyAlbumType.LP, 2019, url);
    }

    [Fact]
    public async Task GetAlbumWithTracksInfoAsync_ShouldBeNotNull_Test()
    {
        var url = "https://musify.club/release/assassination-circles-within-circles-2019-1225489";
        var result = await _musifyTracksData.GetAlbumWithTracksInfoAsync(url);

        Assert.True(result.IsOk);
        Assert.Null(result.ExceptionThrowed);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task GetAlbumWithTracksInfoAsync_ShouldBeExpectedAlbumData_Test()
    {
        var url = "https://musify.club/release/assassination-circles-within-circles-2019-1225489";
        var result = await _musifyTracksData.GetAlbumWithTracksInfoAsync(url);
        var data = result.Data!;

        AssertionHelpers.AlbumAssert(data, "Circles Within Circles", MusifyAlbumType.LP, 2019, url);
        Assert.NotNull(data.CoverData);

        Assert.Collection(data.Artists,
            a => AssertionHelpers.ArtistInfoAssert("Assassination", "Германия", "https://musify.club/artist/assassination-374737", a));

        Assert.Collection(data.Genres,
            g => Assert.Equal("Psychedelic Rock", g.Name),
            g => Assert.Equal("Occult Rock", g.Name));

        Assert.All(data.Tracks, t =>
        {
            var artist = t.Artists.Single();

            Assert.NotEqual(TimeSpan.Zero, t.Duration);
            Assert.NotNull(t.Url);
            Assert.NotNull(t.DownloadUrl);
            Assert.EndsWith(".mp3", t.DownloadUrl);
            Assert.NotNull(t.Title);
            Assert.All(t.Artists, a =>
            {
                Assert.Equal(artist, a);
            });
        });
    }

    [Fact]
    public async Task GetAlbumWithTracksInfoAsync_ShouldHaveTwoDifferentArtistsOnTracks_Test()
    {
        var url = "https://musify.club/release/vinterriket-and-paysage-dhiver-2003-205226";
        var result = await _musifyTracksData.GetAlbumWithTracksInfoAsync(url);
        var data = result.Data!;

        AssertionHelpers.AlbumAssert(data, "Vinterriket & Paysage D'Hiver", MusifyAlbumType.Split, 2003, url);
        Assert.NotNull(data.CoverData);

        Assert.Collection(data.Artists,
            a => AssertionHelpers.ArtistInfoAssert("Paysage D'Hiver", "Швейцария", "https://musify.club/artist/paysage-dhiver-31910", a),
            a => AssertionHelpers.ArtistInfoAssert("Vinterriket", "Германия", "https://musify.club/artist/vinterriket-21151", a));
    }

    [Fact]
    public async Task GetAlbumWithTracksInfoAsync_ShouldHaveMoreThanOneArtistOnTracks_Test()
    {
        var url = "https://musify.club/release/lovers-on-the-sun-2014-517105";
        var result = await _musifyTracksData.GetAlbumWithTracksInfoAsync(url);
        var data = result.Data!;

        var davidGuetta = "David Guetta";
        var samMartin = "Sam Martin";
        var kazJames = "Kaz James";
        var vassy = "Vassy";
        var showtek = "Showtek";
        var skylarGrey = "Skylar Grey";

        AssertionHelpers.AlbumAssert(data, "Lovers On The Sun", MusifyAlbumType.EP, 2014, url);

        Assert.Collection(data.Artists,
            a => AssertionHelpers.ArtistInfoAssert(davidGuetta, "Франция", "https://musify.club/artist/david-guetta-608", a),
            a => AssertionHelpers.ArtistInfoAssert(samMartin, "Соединенные Штаты", "https://musify.club/artist/sam-martin-314289", a),
            a => AssertionHelpers.ArtistInfoAssert(kazJames, "Великобритания", "https://musify.club/artist/kaz-james-143018", a),
            a => AssertionHelpers.ArtistInfoAssert(vassy, "Австралия", "https://musify.club/artist/vassy-6298", a),
            a => AssertionHelpers.ArtistInfoAssert(showtek, "Нидерланды", "https://musify.club/artist/showtek-7188", a),
            a => AssertionHelpers.ArtistInfoAssert(skylarGrey, "Соединенные Штаты", "https://musify.club/artist/skylar-grey-65835", a));

        Assert.Collection(data.Tracks,
            t => AssertionHelpers.TrackAssert(t, "Lovers On The Sun (feat. Sam Martin)", davidGuetta, samMartin),
            t => AssertionHelpers.TrackAssert(t, "Blast Off (feat. Kaz James)", davidGuetta, kazJames),
            t => AssertionHelpers.TrackAssert(t, "Bad (feat. Showtek & Vassy)", davidGuetta, vassy, showtek),
            t => AssertionHelpers.TrackAssert(t, "Shot Me Down (feat. Skylar Grey)", davidGuetta, skylarGrey));
    }
}