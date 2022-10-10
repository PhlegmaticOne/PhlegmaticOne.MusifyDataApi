using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Base;
using PhlegmaticOne.MusifyDataApi.Dtos.Years;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

public class ReleasePreviewDtoBase : ReleaseDtoBase
{
    public string ArtistName { get; init; } = null!;
    public YearDto YearReleased { get; init; } = null!;
}