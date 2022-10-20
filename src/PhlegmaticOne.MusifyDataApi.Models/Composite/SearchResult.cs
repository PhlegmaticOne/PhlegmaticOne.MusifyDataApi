namespace PhlegmaticOne.MusifyDataApi.Models.Composite;

public class SearchResult<T> where T : class
{
    public List<T> Items { get; set; } = null!;
    public override string ToString() => $"Items count: {Items.Count}";
}
