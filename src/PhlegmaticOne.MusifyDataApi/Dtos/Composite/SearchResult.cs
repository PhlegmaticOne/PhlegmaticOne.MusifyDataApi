namespace PhlegmaticOne.MusifyDataApi.Dtos.Composite;

public class SearchResult<T> where T : class
{
    public List<T> Items { get; init; } = null!;
}
