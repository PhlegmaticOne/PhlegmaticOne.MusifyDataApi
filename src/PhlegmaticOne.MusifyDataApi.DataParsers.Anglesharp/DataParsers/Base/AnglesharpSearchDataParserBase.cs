using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Core.Downloads;
using PhlegmaticOne.MusifyDataApi.Core.Extensions;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers.Base;

internal abstract class AnglesharpSearchDataParserBase : AnglesharpDataParserBase<IHtmlDivElement>
{
    private readonly IMusifyDataDownloadService _musifyDataDownloadService;

    protected AnglesharpSearchDataParserBase(IMusifyDataDownloadService musifyDataDownloadService) =>
        _musifyDataDownloadService = musifyDataDownloadService;
    protected abstract string CoverDivName { get; }
    protected async Task<byte[]> GetCoverAsyncCommon(bool includeCover)
    {
        if (includeCover == false) return Array.Empty<byte>();

        var coverDiv = HtmlElement.QuerySelector("div." + CoverDivName)!;
        var imageElement = coverDiv.QuerySelector("img")!;
        var imageUrl = imageElement.GetAttribute("data-src")!;
        return await _musifyDataDownloadService.DownloadAsync(imageUrl.AsMusifyUrl().ToStringUrl());
    }
    protected int GetTracksCountCommon()
    {
        var infoDiv = GetInfoDiv();
        var tracksElement = infoDiv.Children.SkipLast(1).TakeLast(1).First();
        var tracksCount = tracksElement.InnerHtml.Skip(8).ToArray();
        return int.Parse(new string(tracksCount));
    }
    protected string GetUrlCommon()
    {
        var anchor = HtmlElement.QuerySelector("a")!;
        return anchor.GetAttribute("href")!.AsMusifyUrl().ToStringUrl();
    }

    protected IHtmlDivElement GetInfoDiv() => (IHtmlDivElement)HtmlElement.QuerySelector("div.contacts__info")!;
}
