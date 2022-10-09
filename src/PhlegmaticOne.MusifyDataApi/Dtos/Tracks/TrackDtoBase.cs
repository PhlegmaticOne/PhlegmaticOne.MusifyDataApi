using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Tracks;

public class TrackDtoBase : OnlineDtoBase
{
    public string Title { get; init; } = null!;
    public List<ArtistDtoBase> Artists { get; init; } = null!;
    public override string ToString() => $"{Title}";
}