using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;

public interface IPreviewReleasesPageParser : IHtmlPageParserBase
{
    IEnumerable<object> GetReleaseHtmlItems();
}
