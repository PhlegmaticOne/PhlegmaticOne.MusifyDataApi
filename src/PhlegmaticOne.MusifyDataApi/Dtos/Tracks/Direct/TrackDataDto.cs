namespace PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

public class TrackDataDto : TrackInfoDto
{
    public byte[] TrackData { get; init; } = null!;
}