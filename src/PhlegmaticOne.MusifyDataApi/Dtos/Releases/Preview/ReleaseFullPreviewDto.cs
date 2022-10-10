using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

public class ReleaseFullPreviewDto : ReleaseArtistPreviewDto
{
    public List<ArtistDtoBase> Artists { get; init; } = null!;
}
