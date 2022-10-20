using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;

public interface ISearchArtistDataParser : IHtmlDataParserBase
{
    Task<byte[]> GetCoverAsync(bool includeCover);
    string GetName();
    int GetTracksCount();
    string GetUrl();
}
