using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers;

public class AnglesharpReleaseDataParser : AnglesharpPageParserBase, IReleasePageParser
{
    private bool _isMoreThanOneArtist;

    public bool IsMoreThanOneArtistCheck()
    {
        var albumInfo = HtmlDocument.QuerySelectorAll("ul")
            .First(x => x.ClassList.Contains("album-info"))
            .Children;

        var artistsInfo = albumInfo.FirstOrDefault();

        _isMoreThanOneArtist = artistsInfo is not null && artistsInfo.QuerySelectorAll("a").Length > 1;
        return _isMoreThanOneArtist;
    }

    public string GetTitle()
    {
        static string ReturnTitle(string titleInfo)
        {
            var splitted = titleInfo.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return splitted[0].Trim();
        }

        var header = HtmlDocument
            .QuerySelectorAll("h1")
            .Select(x => x.InnerHtml)
            .First()
            .Replace("&amp;", "&");

        if (_isMoreThanOneArtist)
        {
            return ReturnTitle(header);
        }

        var firstDashIndex = header.IndexOf('-');
        var titleInfo = firstDashIndex == -1 ?
            header :
            header.Substring(firstDashIndex + 2, header.Length - firstDashIndex - 2);

        return ReturnTitle(titleInfo);
    }

    public YearDtoBase GetYear()
    {
        var time = HtmlDocument.QuerySelector("time");

        if (time is null)
        {
            return new()
            {
                YearReleased = int.MinValue,
                Url = string.Empty,
                HasValue = false
            };
        }

        var yearElement = time.NextElementSibling!;
        var year = int.Parse(yearElement.InnerHtml);
        var yearLink = yearElement.GetAttribute("href")!;
        return new YearDtoBase()
        {
            HasValue = true,
            Url = yearLink,
            YearReleased = year
        };
    }

    public MusifyReleaseType GetReleaseType()
    {
        var typeString = HtmlDocument
            .QuerySelectorAll("i")
            .Where(s => s.ClassName == "zmdi zmdi-collection-music zmdi-hc-fw")
            .Select(x => x.ParentElement!.TextContent)
            .First()
            .Trim();

        return MusifyReleaseTypeParser.Parse(typeString);
    }

    public IEnumerable<GenreDto> GetGenres()
    {
        var genreElements = HtmlDocument
           .QuerySelectorAll("p")
           .First(p => p.ClassName == "genre__labels")
           .Children;

        var names = genreElements.Select(x => x.InnerHtml.Trim('#'));
        var links = genreElements.Select(x => x.GetAttribute("href")!.WrapWithMusifySiteAddress());

        return names.Zip(links).Select(x => new GenreDto
        {
            Name = x.First,
            Url = x.Second
        });
    }

    public async Task<byte[]> GetReleaseCoverAsync(bool includeCover)
    {
        if (includeCover)
        {
            var image = HtmlDocument.QuerySelectorAll("img")
            .First(p => p.ClassName == "album-img lozad");
            var imageUrlPart = image.Attributes.First(s => s.Name == "data-src").Value;
            return await DownloadImageAsync(imageUrlPart);
        }
        return Array.Empty<byte>();
    }

    public Task<IEnumerable<TrackInfoDto>> GetTracksAsync()
    {
        throw new NotImplementedException();
    }
}