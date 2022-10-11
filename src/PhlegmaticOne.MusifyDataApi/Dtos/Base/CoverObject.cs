using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Base;

public class CoverObject : OnlineDtoBase
{
    public byte[] CoverData { get; init; } = Array.Empty<byte>();
}