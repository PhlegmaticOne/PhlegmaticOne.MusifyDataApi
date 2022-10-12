using System.Text;
using PhlegmaticOne.MusifyDataApi.Models.Categories.Builders.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.Categories.Builders.Hits;

public class HitsCategoryBuilder : ISearchCategoryStringBuilder
{
    private readonly string _hitsUrl;
    private int _year;
    private bool _isTop100Week;
    private bool _isTop100Month;
    internal HitsCategoryBuilder(string hitsUrl)
    {
        _hitsUrl = hitsUrl;
    }
    public HitsCategoryBuilder WithYear(int year)
    {
        if (_isTop100Month || _isTop100Week)
        {
            return this;
        }

        _year = year;
        return this;
    }
    public HitsCategoryBuilder Top100Week()
    {
        if (_isTop100Month || _year != 0)
        {
            return this;
        }

        _isTop100Week = true;
        return this;
    }
    public HitsCategoryBuilder Top100Month()
    {
        if (_isTop100Week || _year != 0)
        {
            return this;
        }

        _isTop100Month = true;
        return this;
    }

    public ISearchCategoryString BuildCategoryString()
    {
        var result = new StringBuilder();
        result.Append(_hitsUrl);

        if (_isTop100Week)
        {
            result.Append($"/top100week");
        }

        if (_isTop100Month)
        {
            result.Append($"/top100month");
        }

        if (_year != 0)
        {
            result.Append($"/{_year}");
        }

        return new SearchCategoryString(result.ToString());
    }
}
