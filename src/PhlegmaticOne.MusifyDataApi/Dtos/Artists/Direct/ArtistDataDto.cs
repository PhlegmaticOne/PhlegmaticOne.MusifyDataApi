using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Artists.Direct;

public class ArtistDataDto<TRelease> : ArtistInfoDto where TRelease : ReleaseDtoBase
{
    public List<TRelease> Releases { get; init; } = null!;
}