using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers.Base;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Core;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;

internal class AnglesharpSearchPageParser : AnglesharpPageParserBase, ISearchPageParser
{
    public AnglesharpSearchPageParser(IHtmlStringGetter htmlStringGetter) : base(htmlStringGetter) { }

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
            .Select(x => x.FirstElementChild)!
            .ToList();

        return count > htmlElements.Count ? htmlElements! : (IEnumerable<object>)htmlElements.Take(count);
    }
}
