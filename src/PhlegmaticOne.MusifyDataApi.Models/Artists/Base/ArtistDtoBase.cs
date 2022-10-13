using PhlegmaticOne.MusifyDataApi.Models.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Artists.Base;

public class ArtistDtoBase : CoverObject
{
    public string Name { get; set; } = null!;
    public override string ToString() => Name;
}