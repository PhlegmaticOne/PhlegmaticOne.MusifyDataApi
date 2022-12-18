using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers.Base;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;

internal class AnglesharpSearchArtistDataParser : AnglesharpSearchDataParserBase, ISearchArtistDataParser
{
    protected override string CoverDivName => "contacts__img";
    public AnglesharpSearchArtistDataParser(IMusifyDataDownloadService musifyDataDownloadService) : base(musifyDataDownloadService)
    {
    }
    public Task<byte[]> GetCoverAsync(bool includeCover) => GetCoverAsyncCommon(includeCover);

    public string GetName()
    {
        var info = GetInfoDiv();
        return info.Children[0].InnerHtml;
    }

    public int GetTracksCount() => GetTracksCountCommon();

    public string GetUrl() => GetUrlCommon();
}
