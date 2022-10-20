using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Base;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;

public class ReleaseInfoDto : ReleaseDtoBase
{
    public MusifyReleaseType ReleaseType { get; set; }
    public YearDtoBase YearReleased { get; set; } = null!;
    public override string ToString() => $"{Title} - {YearReleased} [{ReleaseType}]";
}