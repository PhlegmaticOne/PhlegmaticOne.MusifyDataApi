using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusifyDataApi.Dtos;
using PhlegmaticOne.MusifyDataApi.Dtos.Albums;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists;

namespace PhlegmaticOne.MusifyDataApi.Tests;

internal static class AssertionHelpers
{
    internal static void ArtistInfoAssert(string expectedName, string expetctedCountry, string expectedUrl, ArtistDtoBase actual)
    {
        Assert.Equal(expectedName, actual.Name);
        Assert.Equal(expetctedCountry, actual.Country);
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

    internal static void AlbumAssert(AlbumInfoDto actual, string expectedName, MusifyAlbumType expectedAlbumType, int expectedYear, string expectedUrl)
    {
        Assert.Equal(expectedName, actual.Title);
        Assert.Equal(expectedAlbumType, actual.AlbumType);
        Assert.Equal(expectedUrl, actual.Url);
        Assert.Equal(expectedYear, actual.YearReleased);
    }
}
