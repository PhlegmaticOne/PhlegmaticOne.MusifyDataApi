using PhlegmaticOne.MusifyDataApi.Dtos.Genres;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

public class ReleaseArtistPreviewDto : ReleasePreviewDtoBase
{
    public List<GenreDto> Genres { get; init; } = null!;
}
