namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

public class ReleasePreviewDto : ReleaseDtoBase
{
    public string ArtistName { get; init; } = null!;
    public int YearReleased { get; init; }
    public int TracksCount { get; init; }
}