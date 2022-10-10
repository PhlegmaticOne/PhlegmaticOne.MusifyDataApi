using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusifyDataApi.Dtos.Labels;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;

public class ReleaseInfoDto : ReleaseDtoBase
{
    public MusifyAlbumType ReleaseType { get; init; }
    public int YearReleased { get; init; }
    public LabelDto? Label { get; init; }
    public override string ToString() => $"{Title} - {YearReleased} [{ReleaseType}]";
}