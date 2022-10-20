using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers.Base;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Core;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;

public class AnglesharpPreviewReleasesPageParser : AnglesharpPageParserBase, IPreviewReleasesPageParser
{
    public AnglesharpPreviewReleasesPageParser(IHtmlStringGetter htmlStringGetter) : base(htmlStringGetter) { }

    public IEnumerable<object> GetReleaseHtmlItems() => HtmlDocument
            .QuerySelectorAll("div.card.release-thumbnail");
}