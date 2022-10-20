using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;

public interface IPreviewReleasesPageParser : IHtmlPageParserBase
{
    IEnumerable<object> GetReleaseHtmlItems();
}
