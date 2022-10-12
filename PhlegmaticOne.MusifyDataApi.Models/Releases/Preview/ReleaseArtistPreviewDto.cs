using PhlegmaticOne.MusifyDataApi.Models.Genres;

namespace PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

public class ReleaseArtistPreviewDto : ReleasePreviewDtoBase
{
    public List<GenreDto> Genres { get; set; } = null!;
}
