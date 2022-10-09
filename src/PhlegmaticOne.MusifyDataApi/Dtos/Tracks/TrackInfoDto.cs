using PhlegmaticOne.MusifyDataApi.Dtos.Tracks;

namespace PhlegmaticOne.MusifyDataApi.Dtos;

public class TrackInfoDto : TrackDtoBase
{
    public string DownloadUrl { get; init; } = null!;
    public TimeSpan Duration { get; init; }
    public override string ToString() => $"{Title} - {Duration:c}";
}