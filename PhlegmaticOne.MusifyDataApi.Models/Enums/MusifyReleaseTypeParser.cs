namespace PhlegmaticOne.MusifyDataApi.Models.Enums;

public static class MusifyReleaseTypeParser
{
    public static MusifyReleaseType Parse(string value) => value switch
    {
        "Тип не назначен" => MusifyReleaseType.None,
        "Студийный альбом" => MusifyReleaseType.LP,
        "EP" => MusifyReleaseType.EP,
        "Сингл" => MusifyReleaseType.Single,
        "Бутлег" => MusifyReleaseType.Bootleg,
        "Live" => MusifyReleaseType.Live,
        "Сборник разных исполнителей" => MusifyReleaseType.ArtistsCompilation,
        "Микстейп" => MusifyReleaseType.Mixtape,
        "Демо" => MusifyReleaseType.Demo,
        "Сборник исполнителя" => MusifyReleaseType.ArtistCompilation,
        "Split" => MusifyReleaseType.Split,
        "Неофициальный сборник" => MusifyReleaseType.UnofficialCompilation,
        "Саундтрек" => MusifyReleaseType.Soundtrack,
        _ => MusifyReleaseType.None
    };
}