using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Artists;

public class ArtistDtoBase : OnlineDtoBase
{
    public string Name { get; init; } = null!;
    public string Country { get; init; } = null!;
    public override string ToString() => Country is null ? Name : $"{Name} - {Country}";
}