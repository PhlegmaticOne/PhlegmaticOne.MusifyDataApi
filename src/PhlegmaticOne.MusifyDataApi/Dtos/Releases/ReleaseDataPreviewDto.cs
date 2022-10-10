namespace PhlegmaticOne.MusifyDataApi.Dtos.Releases;

public class AlbumDataPreviewDto : AlbumPreviewDto
{
    public byte[] CoverData { get; init; } = null!;
}
