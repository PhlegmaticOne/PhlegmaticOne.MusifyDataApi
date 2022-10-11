using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Artists.Preview;

public class ArtistPreviewDtoBase : ArtistDtoBase
{
    public int TracksCount { get; init; }
}