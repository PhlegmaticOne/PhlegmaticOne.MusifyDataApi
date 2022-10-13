using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Artists.Direct;

public class ArtistInfoDto : ArtistDtoBase
{
    public string Country { get; set; } = null!;
    public int TracksCount { get; set; }
    public override string ToString() => $"{Name} - {Country}";
}