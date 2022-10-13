using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Artists.Preview;

public class ArtistPreviewDtoBase : ArtistDtoBase
{
    public int TracksCount { get; set; }
}