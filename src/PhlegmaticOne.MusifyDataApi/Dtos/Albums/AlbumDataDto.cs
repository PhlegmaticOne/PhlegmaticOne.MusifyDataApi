using PhlegmaticOne.MusifyDataApi.Dtos.Artists;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Albums;

public class AlbumDataDto<TTrack> : AlbumInfoDto where TTrack : TrackDtoBase
{
    public byte[] CoverData { get; init; } = null!;
    public List<ArtistDtoBase> Artists { get; init; } = null!;
    public List<TTrack> Tracks { get; init; } = null!;
    public List<string> Genres { get; init; } = null!;
}