using PhlegmaticOne.MusifyDataApi.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Base;

public class ReleaseDtoBase : CoverObject
{
    public string Title { get; init; } = null!;
    public override string ToString() => Title;
}