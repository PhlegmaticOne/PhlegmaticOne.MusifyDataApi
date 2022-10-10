using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Base;

public class ReleaseDtoBase : OnlineDtoBase
{
    public string Title { get; init; } = null!;
    public override string ToString() => Title;
}