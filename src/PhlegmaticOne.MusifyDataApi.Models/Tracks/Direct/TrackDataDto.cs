namespace PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

public class TrackDataDto : TrackInfoDto
{
    public byte[] TrackData { get; set; } = null!;
}