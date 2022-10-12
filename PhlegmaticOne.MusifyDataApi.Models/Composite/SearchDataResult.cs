using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Composite;

public class SearchDataResult<TArtist, TRelease>
    where TArtist : ArtistDtoBase
    where TRelease : ReleaseDtoBase
{
    public SearchResult<TRelease> Releases { get; set; } = null!;
    public SearchResult<TArtist> Artists { get; set; } = null!;
    public override string ToString() => $"Artists: {Artists.Items.Count}. Releases: {Releases.Items.Count}";
}