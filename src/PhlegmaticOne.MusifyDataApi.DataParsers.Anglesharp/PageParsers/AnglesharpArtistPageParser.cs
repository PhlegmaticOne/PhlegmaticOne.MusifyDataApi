using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers.Base;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;

internal class AnglesharpArtistPageParser : AnglesharpPageParserBase, IArtistPageParser
{
    private readonly IMusifyDataDownloadService _musifyDataDownloadService;
    public AnglesharpArtistPageParser(IHtmlStringGetter htmlStringGetter,
        IMusifyDataDownloadService musifyDataDownloadService) : base(htmlStringGetter)
    {
        _musifyDataDownloadService = musifyDataDownloadService;
    }
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
        return await _musifyDataDownloadService.DownloadAsync(imageUrlPart.AsMusifyUrl().ToStringUrl());
    }

    public string GetName() => HtmlDocument.QuerySelector("li.breadcrumb-item.active")!
            .InnerHtml;

    public int GetTracksCount()
    {
        var tabsHtmlItem = HtmlDocument.QuerySelector("ul.nav.nav-tabs.nav-fill")!;
        var tracksTabLink = tabsHtmlItem.QuerySelector("a")!;
        var tracksCountText = tracksTabLink.InnerHtml
            .Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var tracksCount = int.Parse(tracksCountText.ElementAt(1));

        return tracksCount;
    }
}
