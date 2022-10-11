using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Tests;

internal static class AssertionHelpers
{
    internal static void ArtistInfoAssert(string expectedName, string expectedCountry, string expectedUrl, ArtistInfoDto actual)
    {
        Assert.Equal(expectedName, actual.Name);
        Assert.Equal(expectedUrl, actual.Url);
        Assert.Equal(expectedCountry, actual.Country);
    }
    internal static void TrackAssert(TrackInfoDto actual, string expectedName, params string[] expectedArtistNames)
    {
        Assert.Equal(expectedName, actual.Title);

        foreach (var (First, Second) in expectedArtistNames.Zip(actual.Artists))
        {
            Assert.Equal(First, Second.Name);
        }
    }

    internal static void AlbumAssert(ReleaseInfoDto actual, string expectedName, MusifyAlbumType expectedAlbumType, int expectedYear, string expectedUrl)
    {
        Assert.Equal(expectedName, actual.Title);
        Assert.Equal(expectedAlbumType, actual.ReleaseType);
        Assert.Equal(expectedUrl, actual.Url);
        Assert.Equal(expectedYear, actual.YearReleased.YearReleased);
    }
}
