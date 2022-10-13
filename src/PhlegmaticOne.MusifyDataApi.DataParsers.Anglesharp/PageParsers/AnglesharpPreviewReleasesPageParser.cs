using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

public class AnglesharpPreviewReleasesPageParser : AnglesharpPageParserBase, IPreviewReleasesPageParser
{
    public IEnumerable<object> GetReleaseHtmlItems() => HtmlDocument
            .QuerySelectorAll("div.card.release-thumbnail");
}