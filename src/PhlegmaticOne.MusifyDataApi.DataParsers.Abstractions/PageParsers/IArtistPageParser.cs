using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;

public interface IArtistPageParser : IHtmlPageParserBase
{
    string GetCountry();
    string GetName();
    int GetTracksCount();
    Task<byte[]> GetCoverAsync(bool includeCover);
}