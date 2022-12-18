using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers.Base;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;

internal class AnglesharpPreviewReleasesPageParser : AnglesharpPageParserBase, IPreviewReleasesPageParser
{
    public AnglesharpPreviewReleasesPageParser(IHtmlStringGetter htmlStringGetter) : base(htmlStringGetter) { }

    public IEnumerable<object> GetReleaseHtmlItems() => HtmlDocument
            .QuerySelectorAll("div.card.release-thumbnail");
}