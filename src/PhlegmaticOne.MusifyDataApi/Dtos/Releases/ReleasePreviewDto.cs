namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases;

public class AlbumPreviewDto : AlbumDtoBase
{
    public string ArtistName { get; init; } = null!;
    public int YearReleased { get; init; }
    public int TracksCount { get; init; }
}
