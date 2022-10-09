namespace PhlegmaticOne.MusifyDataApi.Dtos;

public class TrackDataDto : TrackInfoDto
{
    public byte[] TrackData { get; init; } = null!;
}