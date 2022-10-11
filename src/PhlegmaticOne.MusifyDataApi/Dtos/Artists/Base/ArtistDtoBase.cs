using PhlegmaticOne.MusifyDataApi.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Artists.Base;

public class ArtistDtoBase : CoverObject
{
    public string Name { get; init; } = null!;
    public override string ToString() => Name;
}