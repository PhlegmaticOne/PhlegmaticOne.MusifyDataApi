using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusifyDataApi.Dtos.Labels;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Base;
using PhlegmaticOne.MusifyDataApi.Dtos.Years;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;

public class ReleaseInfoDto : ReleaseDtoBase
{
    public MusifyAlbumType ReleaseType { get; init; }
    public YearDto YearReleased { get; init; } = null!;
    public LabelDto? Label { get; init; }
    public override string ToString() => $"{Title} - {YearReleased} [{ReleaseType}]";
}