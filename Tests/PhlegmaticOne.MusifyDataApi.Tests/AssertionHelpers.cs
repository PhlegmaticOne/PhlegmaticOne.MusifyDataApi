using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Tests;

internal static class AssertionHelpers
{
    internal static void ArtistInfoAssert(string expectedName, string expectedUrl, ArtistDtoBase actual)
    {
        Assert.Equal(expectedName, actual.Name);
        Assert.Equal(expectedUrl, actual.Url);
    }
    internal static void TrackAssert(TrackInfoDto actual, string expectedName, params string[] expectedArtistNames)
    {
        Assert.Equal(expectedName, actual.Title);

        foreach (var (First, Second) in expectedArtistNames.Zip(actual.Artists))
        {
            Assert.Equal(First, Second.Name);
        }
    }

    internal static void AlbumAssert(ReleaseInfoDto actual, string expectedName, MusifyReleaseType expectedAlbumType, int expectedYear, string expectedUrl)
    {
        Assert.Equal(expectedName, actual.Title);
        Assert.Equal(expectedAlbumType, actual.ReleaseType);
        Assert.Equal(expectedUrl, actual.Url);
        Assert.Equal(expectedYear, actual.YearReleased.YearReleased);
    }
}
