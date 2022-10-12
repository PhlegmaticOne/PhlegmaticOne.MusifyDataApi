using PhlegmaticOne.MusifyDataApi.Models.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Releases.Base;

public class ReleaseDtoBase : CoverObject
{
    public string Title { get; set; } = null!;
    public override string ToString() => Title;
}