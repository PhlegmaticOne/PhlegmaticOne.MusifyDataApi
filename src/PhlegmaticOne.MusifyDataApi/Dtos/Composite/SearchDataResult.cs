using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Composite;

public class SearchDataResult<TArtist, TRelease>
    where TArtist : ArtistDtoBase
    where TRelease : ReleaseDtoBase
{
    public SearchResult<TRelease> Releases { get; init; } = null!;
    public SearchResult<TArtist> Artists { get; init; } = null!;
    public override string ToString() => $"Artists: {Artists.Items.Count}. Releases: {Releases.Items.Count}";
}