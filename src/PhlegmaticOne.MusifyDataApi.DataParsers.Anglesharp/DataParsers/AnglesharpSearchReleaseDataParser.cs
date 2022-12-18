using PhlegmaticOne.MusifyDataApi.Core.Models;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers.Base;
using PhlegmaticOne.MusifyDataApi.Models.Years;
using System.Text.RegularExpressions;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;

internal class AnglesharpSearchReleaseDataParser : AnglesharpSearchDataParserBase, ISearchReleaseDataParser
{
    protected override string CoverDivName => "contacts__img.release";
    public AnglesharpSearchReleaseDataParser(IMusifyDataDownloadService musifyDataDownloadService) : base(musifyDataDownloadService)
    {
    }
    public string GetArtistName()
    {
        var infoDiv = GetInfoDiv();
        var artistName = infoDiv.Children[1].InnerHtml;
        return HtmlStringCleaner.ClearString(Regex.Replace(artistName, @"\s+", " "));
    }

    public string GetTitle()
    {
        var infoDiv = GetInfoDiv();
        return HtmlStringCleaner.ClearString(infoDiv.Children[0].InnerHtml[..^7]);
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
