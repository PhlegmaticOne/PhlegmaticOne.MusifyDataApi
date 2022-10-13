using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers.Base;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.Downloads;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers;

public class AnglesharpPreviewReleaseParser : AnglesharpDataParserBase<IHtmlDivElement>, IPreviewReleaseDataParser
{
    public async Task<byte[]> GetCoverAsync(bool includeCover)
    {
        if(includeCover == false)
        {
            return Array.Empty<byte>();
        }
        var img = HtmlElement.QuerySelector("img.card-img-top.lozad")!;
        var imageUrl = img.GetAttribute("data-src")!;
        return await MusifyImageDownloader.DownloadImageAsync(imageUrl);
    }

    public IEnumerable<GenreDto> GetGenres()
    {
        var genreLinks = HtmlElement.QuerySelector("p.card-text.genre__labels")!
            .Children;
        return genreLinks.Select(x => new GenreDto()
        {
            Name = x.InnerHtml,
            Url = x.GetAttribute("href")!.WrapWithMusifySiteAddress()
        });
    }

    public IEnumerable<ArtistDtoBase> GetArtists()
    {
        var artistElementsContainer = HtmlElement.QuerySelector("h3.card-title");
        if(artistElementsContainer is null)
        {
            return Enumerable.Empty<ArtistDtoBase>();
        } 
        var artistElements = artistElementsContainer.Children;
        return artistElements.Select(x => new ArtistDtoBase()
        {
            Url = x.GetAttribute("href")!.WrapWithMusifySiteAddress(),
            CoverData = Array.Empty<byte>(),
            Name = x.InnerHtml
        });
    }

    public string GetTitle()
    {
        var nameAnchor = HtmlElement.QuerySelector("h4.card-subtitle")!.FirstElementChild!;
        return nameAnchor.InnerHtml.Replace("&amp;", "&").Trim();
    }

    public YearDtoBase GetYear()
    {
        var yearElement = HtmlElement.QuerySelector("p.card-text")!;
        var year = int.Parse(yearElement.TextContent);   
        return new()
        {
            Url = year.ToYearUrl(),
            YearReleased = year,
            HasValue = true
        };
    }

    public string GetUrl()
    {
        var anchor = HtmlElement.QuerySelector("a")!;
        return anchor.GetAttribute("href")!.WrapWithMusifySiteAddress();
    }
}
