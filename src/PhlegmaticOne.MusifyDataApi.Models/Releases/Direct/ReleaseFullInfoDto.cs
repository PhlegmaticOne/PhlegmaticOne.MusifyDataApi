using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;

public class ReleaseFullInfoDto : ReleaseFullPreviewDto
{
    public MusifyReleaseType ReleaseType { get; set; }
}