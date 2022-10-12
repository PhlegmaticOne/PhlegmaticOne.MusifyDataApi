using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

public class ReleaseFullPreviewDto : ReleaseArtistPreviewDto
{
    public List<ArtistDtoBase> Artists { get; set; } = null!;
}