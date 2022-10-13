using PhlegmaticOne.MusifyDataApi.Models.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Years;

public class YearDtoBase : OnlineDtoBase
{
    public int YearReleased { get; set; }
    public bool HasValue { get; set; }
    public override string ToString() => YearReleased.ToString();
}
