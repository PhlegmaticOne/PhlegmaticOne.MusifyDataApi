using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

public class AnglesharpSearchPageParser : AnglesharpPageParserBase, ISearchPageParser
{
    public IEnumerable<object> GetArtistHtmlItems(int count = 5) =>
        GetSearchItems(0, count);

    public IEnumerable<object> GetReleaseHtmlItems(int count = 20) =>
        GetSearchItems(1, count);

    private IEnumerable<object> GetSearchItems(int index, int count)
    {
        var elements = HtmlDocument.QuerySelectorAll("div.contacts.row").ToList();

        if (elements.Any() == false)
        {
            return Enumerable.Empty<object>();
        }

        var htmlElements =  elements[index]
            .Children!
            .Select(x => x.FirstElementChild)!;

        return count > elements.Count ? elements! : (IEnumerable<object>)elements.Take(count);
    }
}
