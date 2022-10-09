using PhlegmaticOne.MusifyDataApi.Dtos.Albums;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Artists;

public class ArtistDataDto<T> : ArtistDtoBase where T : AlbumDtoBase
{
    public List<T> Releases { get; init; } = null!;
}