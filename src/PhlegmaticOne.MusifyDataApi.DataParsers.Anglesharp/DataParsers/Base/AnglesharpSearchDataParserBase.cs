using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.Downloads;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers.Base;

public abstract class AnglesharpSearchDataParserBase : AnglesharpDataParserBase<IHtmlDivElement>
{
    protected abstract string CoverDivName { get; }
    protected async Task<byte[]> GetCoverAsyncCommon(bool includeCover)
    {
        if (includeCover == false) return Array.Empty<byte>();

        var coverDiv = HtmlElement.QuerySelector("div." + CoverDivName)!;
        var imageElement = coverDiv.QuerySelector("img")!;
        var imageUrl = imageElement.GetAttribute("data-src")!;
        return await MusifyImageDownloader.DownloadImageAsync(imageUrl);
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
        return anchor.GetAttribute("href")!.WrapWithMusifySiteAddress();
    }

    protected IHtmlDivElement GetInfoDiv() => (IHtmlDivElement)HtmlElement.QuerySelector("div.contacts__info")!;
}
