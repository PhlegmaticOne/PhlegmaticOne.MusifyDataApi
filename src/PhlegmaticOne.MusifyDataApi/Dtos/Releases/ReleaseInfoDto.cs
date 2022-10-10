using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases;

public class AlbumInfoDto : AlbumDtoBase
{
    public MusifyAlbumType AlbumType { get; init; }
    public int YearReleased { get; init; }
    public override string ToString() => $"{Title} - {YearReleased} [{AlbumType}]";
}