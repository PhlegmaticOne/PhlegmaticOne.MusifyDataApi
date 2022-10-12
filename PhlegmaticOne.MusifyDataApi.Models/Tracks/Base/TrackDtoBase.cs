using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Tracks.Base;

public class TrackDtoBase : OnlineDtoBase
{
    public string Title { get; set; } = null!;
    public List<ArtistDtoBase> Artists { get; set; } = null!;
    public override string ToString() => $"{Title}";
}