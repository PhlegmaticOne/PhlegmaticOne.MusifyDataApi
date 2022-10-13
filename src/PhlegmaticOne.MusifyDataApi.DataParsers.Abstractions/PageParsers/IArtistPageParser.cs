using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;

public interface IArtistPageParser : IHtmlPageParserBase
{
    string GetCountry();
    string GetName();
    int GetTracksCount();
    Task<byte[]> GetCoverAsync(bool includeCover);
}