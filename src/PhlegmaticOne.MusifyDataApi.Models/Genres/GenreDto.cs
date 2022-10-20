using PhlegmaticOne.MusifyDataApi.Models.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Genres;

public class GenreDto : OnlineDtoBase
{
    public string Name { get; set; } = null!;
    public override string ToString() => Name;
}