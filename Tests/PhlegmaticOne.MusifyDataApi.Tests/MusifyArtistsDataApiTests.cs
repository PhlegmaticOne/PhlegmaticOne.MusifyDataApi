using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusicHttpDataApi.Musify;
using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusicHttpDataApi.Musify.Extensions;
using PhlegmaticOne.MusifyDataApi.Extensions;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class MusifyArtistsDataApiTests
{
    private readonly IMusifyArtistsDataService _musifyArtistsData;

    public MusifyArtistsDataApiTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMusifyDataApi();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _musifyArtistsData = serviceProvider.GetRequiredService<IMusifyArtistsDataService>();
    }

    [Fact]
    public async Task GetArtistInfoAsync_ShouldBeEqualToExpectedData_Test()
    {
        var url = "https://musify.club/artist/deathspell-omega-25080";
        var artist = await _musifyArtistsData.GetArtistInfoAsync(url);
        var data = artist.Data!;

        AssertionHelpers.ArtistInfoAssert("Deathspell Omega", "Франция", url, data);
    }

    [Fact]
    public async Task GetArtistWithAlbumsInfoAsync_ShouldBeEqualToExpectedData_Test()
    {
        var url = "https://musify.club/artist/amesoeurs-22349";
        var artist = await _musifyArtistsData.GetArtistWithAlbumsInfoAsync(url);
        var data = artist.Data!;

        AssertionHelpers.ArtistInfoAssert("Amesoeurs", "Франция", url, data);

        Assert.Collection(data.Releases,
            a => AssertionHelpers.AlbumAssert(a, "Ruines Humaines", MusifyAlbumType.EP, 2006, "https://musify.club/release/amesoeurs-ruines-humaines-2006-31587"),
            a => AssertionHelpers.AlbumAssert(a, "Split with Valfunde", MusifyAlbumType.Split, 2007, "https://musify.club/release/split-with-valfunde-2007-35307"),
            a => AssertionHelpers.AlbumAssert(a, "Amesoeurs", MusifyAlbumType.LP, 2009, "https://musify.club/release/amesoeurs-amesoeurs-2009-31151"));
    }

    [Fact]
    public async Task GetArtistWithAlbumsAndTracksInfoAsync_ShouldBeEqualToExpectedData_Test()
    {
        var url = "https://musify.club/artist/amesoeurs-22349";
        var artist = await _musifyArtistsData.GetArtistWithAlbumsAndTracksInfoAsync(url);
        var data = artist.Data!;

        AssertionHelpers.ArtistInfoAssert("Amesoeurs", "Франция", url, data);

        Assert.Collection(data.Releases,
            a => AssertionHelpers.AlbumAssert(a, "Ruines Humaines", MusifyAlbumType.EP, 2006, "https://musify.club/release/amesoeurs-ruines-humaines-2006-31587"),
            a => AssertionHelpers.AlbumAssert(a, "Split with Valfunde", MusifyAlbumType.Split, 2007, "https://musify.club/release/split-with-valfunde-2007-35307"),
            a => AssertionHelpers.AlbumAssert(a, "Amesoeurs", MusifyAlbumType.LP, 2009, "https://musify.club/release/amesoeurs-amesoeurs-2009-31151"));
    }

    [Fact]
    public async Task GetArtistWithAlbumsInfoAsync_IncludeSplit_Test()
    {
        var url = "https://musify.club/artist/amesoeurs-22349";
        var types = MusifyReleaseTypesProvider.FromTypes(MusifyAlbumType.Split);
        var artist = await _musifyArtistsData.GetArtistWithAlbumsAndTracksInfoAsync(url,
            releaseTypes: types);

        var data = artist.Data!;

        AssertionHelpers.ArtistInfoAssert("Amesoeurs", "Франция", url, data);

        Assert.Collection(data.Releases,
            a => AssertionHelpers.AlbumAssert(a, "Split with Valfunde", MusifyAlbumType.Split, 2007, "https://musify.club/release/split-with-valfunde-2007-35307"));
    }

    [Fact]
    public async Task GetArtistWithAlbumsInfoAsync_IncludeMoreThanOneType_Test()
    {
        var url = "https://musify.club/artist/burzum-7862";
        var types = MusifyReleaseTypesProvider.FromTypes(MusifyAlbumType.LP, MusifyAlbumType.EP);
        var artist = await _musifyArtistsData
            .GetArtistWithAlbumsAndTracksInfoAsync(url, releaseTypes: types);

        var data = artist.Data!;

        Assert.Equal(15, data.Releases.Count);
    }

    [Fact]
    public async Task GetArtistWithAlbumsInfoAsync_Exclude_Test()
    {
        var url = "https://musify.club/artist/amesoeurs-22349";
        var exclude = MusifyReleaseTypesProvider.DefaultExcludeTypes.With(MusifyAlbumType.Split);

        var artist = await _musifyArtistsData.GetArtistWithAlbumsAndTracksInfoAsync(url,
            selectionType: SelectionType.Exclude,
            releaseTypes: exclude);

        var data = artist.Data!;

        AssertionHelpers.ArtistInfoAssert("Amesoeurs", "Франция", url, data);

        Assert.Collection(data.Releases,
            a => AssertionHelpers.AlbumAssert(a, "Ruines Humaines", MusifyAlbumType.EP, 2006, "https://musify.club/release/amesoeurs-ruines-humaines-2006-31587"),
            a => AssertionHelpers.AlbumAssert(a, "Amesoeurs", MusifyAlbumType.LP, 2009, "https://musify.club/release/amesoeurs-amesoeurs-2009-31151"));
    }
}
