using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.Downloads;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

public class AnglesharpArtistPageParser : AnglesharpPageParserBase, IArtistPageParser
{
    public string GetCountry()
    {
        var artistInfo = HtmlDocument.QuerySelector("ul.icon-list")!
            .Children
            .SelectMany(x => x.Children);

        var countryElement = artistInfo
            .FirstOrDefault(x => x.ClassName is not null && x.ClassName.Contains("flag-icon"));

        return countryElement is null ? string.Empty : countryElement!.ParentElement!.TextContent.Trim();
    }

    public async Task<byte[]> GetCoverAsync(bool includeCover)
    {
        if (!includeCover) return Array.Empty<byte>();

        var image = HtmlDocument.QuerySelector("img.artist-img")!;
        var imageUrlPart = image.Attributes.First(s => s.Name == "src").Value;
        return await MusifyImageDownloader.DownloadImageAsync(imageUrlPart);
    }

    public string GetName() => HtmlDocument.QuerySelector("li.breadcrumb-item.active")!
            .InnerHtml;

    public int GetTracksCount()
    {
        var tabsHtmlItem = HtmlDocument.QuerySelector("ul.nav.nav-tabs.nav-fill")!;
        var tracksTabLink = tabsHtmlItem.QuerySelector("a")!;
        var tracksCountText = tracksTabLink.InnerHtml
            .Split(new [] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var tracksCount = int.Parse(tracksCountText.ElementAt(1));

        return tracksCount;
    }
}
