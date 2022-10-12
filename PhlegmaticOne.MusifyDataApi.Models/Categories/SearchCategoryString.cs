namespace PhlegmaticOne.MusifyDataApi.Models.Categories;

public class SearchCategoryString : ISearchCategoryString
{
    private readonly string _categoryString;

    internal SearchCategoryString(string categoryString) => _categoryString = categoryString;

    public string GetCategoryString() => _categoryString;
}
