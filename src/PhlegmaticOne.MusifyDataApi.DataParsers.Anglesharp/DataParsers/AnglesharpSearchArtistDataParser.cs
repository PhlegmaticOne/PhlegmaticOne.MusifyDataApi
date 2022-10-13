using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers;

public class AnglesharpSearchArtistDataParser : AnglesharpSearchDataParserBase, ISearchArtistDataParser
{
    protected override string CoverDivName => "contacts__img";

    public Task<byte[]> GetCoverAsync(bool includeCover) => GetCoverAsyncCommon(includeCover);

    public string GetName()
    {
        var info = GetInfoDiv();
        return info.Children[0].InnerHtml;
    }

    public int GetTracksCount() => GetTracksCountCommon();

    public string GetUrl() => GetUrlCommon();
}
