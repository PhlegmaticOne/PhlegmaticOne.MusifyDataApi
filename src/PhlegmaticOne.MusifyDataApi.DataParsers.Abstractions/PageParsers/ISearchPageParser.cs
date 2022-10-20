using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;

public interface ISearchPageParser : IHtmlPageParserBase
{
    IEnumerable<object> GetReleaseHtmlItems(int count = 20);
    IEnumerable<object> GetArtistHtmlItems(int count = 5);
}