using PhlegmaticOne.MusifyDataApi.Core.Downloads;
using PhlegmaticOne.MusifyDataApi.Core.Models;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers.Base;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;

public class AnglesharpSearchReleaseDataParser : AnglesharpSearchDataParserBase, ISearchReleaseDataParser
{
    protected override string CoverDivName => "contacts__img.release";
    public AnglesharpSearchReleaseDataParser(IMusifyDataDownloadService musifyDataDownloadService) : base(musifyDataDownloadService)
    {
    }
    public string GetArtistName()
    {
        var infoDiv = GetInfoDiv();
        return infoDiv.Children[1].InnerHtml.Trim('\n', ' ');
    }

    public string GetTitle()
    {
        var infoDiv = GetInfoDiv();
        return infoDiv.Children[0].InnerHtml[..^7].Trim();
    }
    public YearDtoBase GetYear()
    {
        var infoDiv = GetInfoDiv();
        var yearString = infoDiv.Children[0].InnerHtml[^4..];
        var year = int.Parse(yearString);
        return new()
        {
            YearReleased = year,
            Url = MusifyUrl.BuildYearUrl(year).ToStringUrl()
        };
    }

    public int GetTracksCount() => GetTracksCountCommon();
    public string GetUrl() => GetUrlCommon();
    public Task<byte[]> GetCoverAsync(bool includeCover) => GetCoverAsyncCommon(includeCover);
}
