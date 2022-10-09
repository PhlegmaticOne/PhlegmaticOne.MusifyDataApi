using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using PhlegmaticOne.MusicHttpDataApi.Musify;
using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusifyDataApi.Dtos.Albums;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusifyDataApi.Helpers.Html;

internal static class ArtistHelpers
{
    private static readonly List<string> _restrictedTypes;
    static ArtistHelpers() => _restrictedTypes = new() { "1", "7", "8", "13" };
    internal static async Task<string> GetCountry(string url)
    {
        var httpClient = HttpClientSingleton.Instance;
        var source = await httpClient.GetStringAsync(url);
        var parser = new HtmlParser();
        var domDocument = await parser.ParseDocumentAsync(source);

        return GetCountry(domDocument);
    }

    internal static string GetCountry(IHtmlDocument htmlDocument)
    {
        var artistInfo = htmlDocument.QuerySelectorAll("ul")
            .Where(x => x.ClassName == "icon-list")
            .First()
            .Children
            .SelectMany(x => x.Children);

        var countryElement = artistInfo
            .FirstOrDefault(x => x.ClassName is not null && x.ClassName.Contains("flag-icon"));

        return countryElement is null ? string.Empty : countryElement!.ParentElement!.TextContent.Trim();
    }
    internal static string GetName(IHtmlDocument htmlDocument) => htmlDocument.QuerySelectorAll("li")
            .Where(x => x.ClassName == "breadcrumb-item active")
            .First()
            .InnerHtml;

    internal static async Task<IEnumerable<string>> GetAlbumUrls(string url, SelectionType selectionType = SelectionType.Include, params MusifyAlbumType[] releaseTypes)
    {
        var document = await HttpClientSingleton.GetDocumentAsync(CommonHelpers.ToReleaseUrl(url));
        var albumTypes = new List<MusifyAlbumType>();
        var isInclude = selectionType == SelectionType.Include;
        if (releaseTypes.Length > 0)
        {
            albumTypes.AddRange(releaseTypes);
        }
        else
        {
            if (selectionType == SelectionType.Include)
            {
                albumTypes.AddRange(MusifyAlbumTypesCollections.DefaultIncludeTypes);
            }
            else
            {
                albumTypes.AddRange(MusifyAlbumTypesCollections.DefaultExcludeTypes);
            }
        }
        var proceedTypes = albumTypes.Cast<int>().Select(x => x.ToString()).ToList();

        var result = document
            .QuerySelectorAll("div")
            .Where(x => x.ClassName == "card release-thumbnail" && proceedTypes.Contains(x.GetAttribute("data-type")!) == isInclude)
            .Select(x => x.Children.First())
            .Select(x => CommonHelpers.WrapWithMusifySiteAddress(x.GetAttribute("href")!));
        return result;
    }

    internal static ArtistDataDto<T> GetArtistResult<T>(ArtistDtoBase artistDtoBase, string url) where T : AlbumDtoBase => new()
    {
        Country = artistDtoBase.Country,
        Name = artistDtoBase.Name,
        Url = url,
        Releases = new List<T>()
    };
}
