using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;

namespace PhlegmaticOne.MusicHttpDataApi.Musify.Helpers;

internal static class MusifyAlbumTypeParser
{
    internal static MusifyAlbumType Parse(string value) => value switch
    {
        "Тип не назначен" => MusifyAlbumType.None,
        "Студийный альбом" => MusifyAlbumType.LP,
        "EP" => MusifyAlbumType.EP,
        "Сингл" => MusifyAlbumType.Single,
        "Бутлег" => MusifyAlbumType.Bootleg,
        "Live" => MusifyAlbumType.Live,
        "Сборник разных исполнителей" => MusifyAlbumType.ArtistsCompilation,
        "Микстейп" => MusifyAlbumType.Mixtape,
        "Демо" => MusifyAlbumType.Demo,
        "Сборник исполнителя" => MusifyAlbumType.ArtistCompilation,
        "Split" => MusifyAlbumType.Split,
        "Неофициальный сборник" => MusifyAlbumType.UnofficialCompilation,
        "Саундтрек" => MusifyAlbumType.Soundtrack,
        _ => MusifyAlbumType.None
    };
}
