using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;

public interface ISearchReleaseDataParser : IHtmlDataParserBase
{
    Task<byte[]> GetCoverAsync(bool includeCover);
    int GetTracksCount();
    string GetName();
    string GetUrl();
    YearDtoBase GetYear();
}