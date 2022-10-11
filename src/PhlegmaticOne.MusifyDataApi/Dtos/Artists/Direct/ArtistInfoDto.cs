using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Artists.Direct;

public class ArtistInfoDto : ArtistDtoBase
{
    public string Country { get; init; } = null!;
    public int TracksCount { get; init; }
    public override string ToString() => $"{Name} - {Country}";
}