using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusifyDataApi.Dtos.Labels;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

public class ReleaseFullInfoPreviewDto : ReleaseFullPreviewDto
{
    public MusifyAlbumType ReleaseType { get; init; }
    public LabelDto? Label { get; init; }
}
