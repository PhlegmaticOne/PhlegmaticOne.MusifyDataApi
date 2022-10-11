using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

public class TrackInfoDto : TrackDtoBase
{
    public string DownloadUrl { get; init; } = null!;
    public TimeSpan Duration { get; init; }
    public override string ToString() => $"{Title} - {Duration:c}";
}