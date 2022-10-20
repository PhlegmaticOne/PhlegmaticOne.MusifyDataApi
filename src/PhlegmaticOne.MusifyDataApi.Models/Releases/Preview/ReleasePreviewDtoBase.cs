using PhlegmaticOne.MusifyDataApi.Models.Releases.Base;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

public class ReleasePreviewDtoBase : ReleaseDtoBase
{
    public string ArtistName { get; set; } = null!;
    public YearDtoBase YearReleased { get; set; } = null!;
}