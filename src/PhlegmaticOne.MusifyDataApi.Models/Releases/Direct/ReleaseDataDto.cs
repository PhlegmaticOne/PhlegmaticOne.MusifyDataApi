using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;

public class ReleaseDataDto<TTrack> : ReleaseInfoDto where TTrack : TrackDtoBase
{
    public List<ArtistDtoBase> Artists { get; set; } = null!;
    public List<TTrack> Tracks { get; set; } = null!;
    public List<GenreDto> Genres { get; set; } = null!;
}