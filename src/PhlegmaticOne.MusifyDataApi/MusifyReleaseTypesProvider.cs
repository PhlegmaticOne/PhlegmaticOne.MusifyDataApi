using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;

namespace PhlegmaticOne.MusicHttpDataApi.Musify;

public static class MusifyReleaseTypesProvider
{
    public static List<MusifyAlbumType> DefaultIncludeTypes =>
        new()
        {
            MusifyAlbumType.ArtistCompilation,
            MusifyAlbumType.Bootleg,
            MusifyAlbumType.Demo,
            MusifyAlbumType.DjRemix,
            MusifyAlbumType.EP,
            MusifyAlbumType.Live,
            MusifyAlbumType.LP,
            MusifyAlbumType.Single,
            MusifyAlbumType.Soundtrack,
            MusifyAlbumType.Split
        };

    public static List<MusifyAlbumType> DefaultExcludeTypes =>
        new()
        {
            MusifyAlbumType.ArtistsCompilation,
            MusifyAlbumType.Mixtape,
            MusifyAlbumType.None,
            MusifyAlbumType.UnofficialCompilation
        };

    public static List<MusifyAlbumType> FromTypes(params MusifyAlbumType[] types) => types.ToList();
    public static List<MusifyAlbumType> All =>
        DefaultExcludeTypes.Concat(DefaultIncludeTypes).ToList();
}
