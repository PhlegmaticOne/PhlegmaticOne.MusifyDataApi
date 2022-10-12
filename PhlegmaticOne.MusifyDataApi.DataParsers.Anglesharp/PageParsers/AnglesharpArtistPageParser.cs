using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

public class AnglesharpArtistPageParser : AnglesharpPageParserBase, IArtistPageParser
{
    public string GetCountry()
    {
        var artistInfo = HtmlDocument.QuerySelectorAll("ul")
            .First(x => x.ClassName == "icon-list")
            .Children
            .SelectMany(x => x.Children);

        var countryElement = artistInfo
            .FirstOrDefault(x => x.ClassName is not null && x.ClassName.Contains("flag-icon"));

        return countryElement is null ? string.Empty : countryElement!.ParentElement!.TextContent.Trim();
    }

    public async Task<byte[]> GetCoverAsync(bool includeCover)
    {
        if (includeCover)
        {
            var image = HtmlDocument.QuerySelectorAll("img").First(x => x.ClassName == "artist-img");
            var imageUrlPart = image.Attributes.First(s => s.Name == "src").Value;
            return await DownloadImageAsync(imageUrlPart);
        }
        return Array.Empty<byte>();
    }

    public string GetName() => HtmlDocument.QuerySelectorAll("li")
            .First(x => x.ClassName == "breadcrumb-item active")
            .InnerHtml;

    public int GetTracksCount()
    {
        var tabsHtmlItem = HtmlDocument.QuerySelector("ul.nav.nav-tabs.nav-fill")!;
        var tracksTabLink = tabsHtmlItem.QuerySelector("a")!;
        var tracksCountText = tracksTabLink.InnerHtml
            .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var tracksCount = int.Parse(tracksCountText.ElementAt(1));

        return tracksCount;
    }
}
