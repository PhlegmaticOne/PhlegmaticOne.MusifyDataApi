using PhlegmaticOne.MusifyDataApi.Models.Tracks.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

public class TrackInfoDto : TrackDtoBase
{
    public string DownloadUrl { get; set; } = null!;
    public TimeSpan Duration { get; set; }
    public override string ToString() => $"{Title} - {Duration:c}";
}