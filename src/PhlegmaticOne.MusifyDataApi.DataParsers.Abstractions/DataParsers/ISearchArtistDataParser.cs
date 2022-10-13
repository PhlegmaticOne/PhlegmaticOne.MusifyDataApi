using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;

public interface ISearchArtistDataParser : IHtmlDataParserBase
{
    Task<byte[]> GetCoverAsync(bool includeCover);
    string GetName();
    int GetTracksCount();
    string GetUrl();
}
