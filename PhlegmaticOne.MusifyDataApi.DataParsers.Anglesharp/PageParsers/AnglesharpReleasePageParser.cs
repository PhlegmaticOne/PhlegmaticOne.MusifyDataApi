using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.Downloads;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers.Base;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

public class AnglesharpReleasePageParser : AnglesharpPageParserBase, IReleasePageParser
{
    public bool IsMoreThanOneArtistCheck()
    {
        var albumInfo = HtmlDocument.QuerySelector("ul.icon-list.album-info")!
            .Children;

        var artistsInfo = albumInfo.FirstOrDefault();

        return artistsInfo is not null && artistsInfo.QuerySelectorAll("a").Length > 1;
    }

    public string GetTitle()
    {
        static string ReturnTitle(string titleInfo)
        {
            var splitted = titleInfo.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return splitted[0].Trim();
        }

        var header = HtmlDocument
            .QuerySelector("h1")!
            .InnerHtml
            .Replace("&amp;", "&");

        if (IsMoreThanOneArtistCheck())
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
        return new YearDtoBase
        {
            HasValue = true,
            Url = yearLink,
            YearReleased = year
        };
    }

    public MusifyReleaseType GetReleaseType()
    {
        var typeString = HtmlDocument
            .QuerySelector("i.zmdi.zmdi-collection-music.zmdi-hc-fw")!
            .ParentElement!.TextContent
            .Trim();

        return MusifyReleaseTypeParser.Parse(typeString);
    }

    public IEnumerable<GenreDto> GetGenres()
    {
        var genreElements = HtmlDocument
           .QuerySelector("p.genre__labels")!
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
        if (!includeCover) return Array.Empty<byte>();

        var image = HtmlDocument.QuerySelector("img.album-img.lozad");
        var imageUrlPart = image.Attributes.First(s => s.Name == "data-src").Value;
        return await MusifyImageDownloader.DownloadImageAsync(imageUrlPart);
    }

    public IEnumerable<TrackInfoDto> GetTracks()
    {
        var result = new List<TrackInfoDto>();
        var existingArtists = new List<ArtistDtoBase>();

        var albumContainer = HtmlDocument
            .QuerySelector("div.playlist.playlist--hover")!;

        foreach (var trackElement in albumContainer.Children)
        {
            var songArtistLinks = trackElement
                .QuerySelectorAll("a")
                .Where(x => x.Attributes.Any(y => y.Name == "rel") && x.InnerHtml != "Flash plugin")
                .ToList();

            var songArtists = songArtistLinks.Select(x => x.InnerHtml);

            var artists = new List<ArtistDtoBase>();
            var current = 0;

            foreach (var songArtist in songArtists)
            {
                var existingArtist = existingArtists.FirstOrDefault(x => x.Name == songArtist);

                if (existingArtist is null)
                {
                    var artistLink = songArtistLinks
                        .Select(x => x.GetAttribute("href")!.WrapWithMusifySiteAddress())
                        .ElementAt(current);

                    var newArtist = new ArtistDtoBase
                    {
                        Name = songArtist,
                        Url = artistLink
                    };

                    artists.Add(newArtist);
                    existingArtists.Add(newArtist);
                }
                else
                {
                    artists.Add(existingArtist);
                }
                current++;
            }

            var songInfo = trackElement
                .QuerySelector("a.strong")!;

            var songName = songInfo.InnerHtml.Replace("&amp;", "&");

            var songLink = songInfo.GetAttribute("href")!.WrapWithMusifySiteAddress();

            var duration = trackElement.QuerySelectorAll("div")
                .Where(d => d.ClassName == "track__details hidden-xs-down" && d.FirstElementChild?.ClassName == "text-muted")
                .Select(x => x.FirstElementChild?.InnerHtml.ToTimeSpan())
                .First()!;

            var downloadUrl = trackElement.QuerySelectorAll("a")
                .Where(p => p.HasAttribute("download"))
                .Select(x => x.GetAttribute("href")!.WrapWithMusifySiteAddress())
                .FirstOrDefault();

            var track = new TrackInfoDto
            {
                Duration = duration.Value,
                DownloadUrl = downloadUrl ?? string.Empty,
                Title = songName,
                Artists = artists,
                Url = songLink,
            };
            result.Add(track);
        }

        return result;
    }
}