using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases;

public class AlbumDtoBase : OnlineDtoBase
{
    public string Title { get; init; } = null!;
    public override string ToString() => Title;
}