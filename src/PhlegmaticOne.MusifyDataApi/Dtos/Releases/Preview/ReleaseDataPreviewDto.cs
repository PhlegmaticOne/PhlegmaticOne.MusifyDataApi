using PhlegmaticOne.MusifyDataApi.Dtos.Artists;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

public class ReleaseDataPreviewDto : ReleasePreviewDto
{
    public ArtistInfoDto Artist { get; init; } = null!;
    public byte[] CoverData { get; init; } = null!;
}
