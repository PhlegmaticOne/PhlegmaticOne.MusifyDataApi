using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.Core.Helpers;

public static class MusifyReleaseTypesProvider
{
    public static List<MusifyReleaseType> DefaultIncludeTypes =>
        new()
        {
            MusifyReleaseType.ArtistCompilation,
            MusifyReleaseType.Bootleg,
            MusifyReleaseType.Demo,
            MusifyReleaseType.DjRemix,
            MusifyReleaseType.EP,
            MusifyReleaseType.Live,
            MusifyReleaseType.LP,
            MusifyReleaseType.Single,
            MusifyReleaseType.Soundtrack,
            MusifyReleaseType.Split
        };

    public static List<MusifyReleaseType> DefaultExcludeTypes =>
        new()
        {
            MusifyReleaseType.ArtistsCompilation,
            MusifyReleaseType.Mixtape,
            MusifyReleaseType.None,
            MusifyReleaseType.UnofficialCompilation
        };

    public static List<MusifyReleaseType> FromTypes(params MusifyReleaseType[] types) => types.ToList();
    public static List<MusifyReleaseType> All =>
        DefaultExcludeTypes.Concat(DefaultIncludeTypes).ToList();
}
