using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Labels;

public class LabelDto : OnlineDtoBase
{
    public string Name { get; init; } = null!;
}