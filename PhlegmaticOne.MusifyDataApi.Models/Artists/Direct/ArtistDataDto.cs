using PhlegmaticOne.MusifyDataApi.Models.Releases.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Artists.Direct;

public class ArtistDataDto<TRelease> : ArtistInfoDto where TRelease : ReleaseDtoBase
{
    public List<TRelease> Releases { get; set; } = null!;
}