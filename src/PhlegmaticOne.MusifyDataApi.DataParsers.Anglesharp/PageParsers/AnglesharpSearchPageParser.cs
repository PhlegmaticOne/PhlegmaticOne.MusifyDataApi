using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers.Base;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;

internal class AnglesharpSearchPageParser : AnglesharpPageParserBase, ISearchPageParser
{
    public AnglesharpSearchPageParser(IHtmlStringGetter htmlStringGetter) : base(htmlStringGetter) { }

    public IEnumerable<object> GetArtistHtmlItems(int count = 5) =>
        GetSearchItems("artists", count);

    public IEnumerable<object> GetReleaseHtmlItems(int count = 20) =>
        GetSearchItems("albums", count);

    private IEnumerable<object> GetSearchItems(string linkId, int count)
    {
        var link = HtmlDocument.GetElementById(linkId);

        if (link is null)
        {
            return Enumerable.Empty<object>();
        }

        var htmlElements = link.NextElementSibling!.NextElementSibling!.Children
            .Select(x => x.FirstElementChild)
            .ToList();

        return count > htmlElements.Count ? htmlElements! : (IEnumerable<object>)htmlElements.Take(count);
    }
}
