namespace PhlegmaticOne.MusifyDataApi.Models.Base;

public class CoverObject : OnlineDtoBase
{
    public byte[] CoverData { get; set; } = Array.Empty<byte>();
}