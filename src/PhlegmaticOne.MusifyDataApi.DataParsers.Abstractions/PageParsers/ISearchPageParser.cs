using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;

public interface ISearchPageParser : IHtmlPageParserBase
{
    IEnumerable<object> GetReleaseHtmlItems(int count = 20);
    IEnumerable<object> GetArtistHtmlItems(int count = 5);
}