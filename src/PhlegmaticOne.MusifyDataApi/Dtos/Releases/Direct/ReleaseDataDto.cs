using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Genres;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;

public class ReleaseDataDto<TTrack> : ReleaseInfoDto where TTrack : TrackDtoBase
{
    public List<ArtistInfoDto> Artists { get; init; } = null!;
    public List<TTrack> Tracks { get; init; } = null!;
    public List<GenreDto> Genres { get; init; } = null!;
}