using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.Genres;

public class GenreDto : OnlineDtoBase
{
    public string Name { get; init; } = null!;
}