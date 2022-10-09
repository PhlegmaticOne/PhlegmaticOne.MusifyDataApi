using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Dtos;
using PhlegmaticOne.MusifyDataApi.Dtos.Albums;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists;
using PhlegmaticOne.MusifyDataApi.Helpers;
using PhlegmaticOne.MusifyDataApi.Helpers.Html;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusicHttpDataApi.Musify.Helpers.Html;

internal static class AlbumHelpers
{
    internal static bool IsMoreThanOneArtistCheck(IHtmlDocument htmlDocument)
    {
        var albumInfo = htmlDocument.QuerySelectorAll("ul")
            .Where(x => x.ClassList.Contains("album-info"))
            .First()
            .Children;

        var artistsInfo = albumInfo.FirstOrDefault();

        return artistsInfo is not null && artistsInfo.QuerySelectorAll("a").Length > 1;
    }

    internal static (string, int) GetTitleAndYearReleased(IHtmlDocument htmlDocument, bool isMoreThanOneArtist)
    {
        static (string, int) ReturnInfo(string titleInfo)
        {
            var splitted = titleInfo.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return (splitted[0].Trim(), int.Parse(splitted[1]));
        }

        var header = htmlDocument
            .QuerySelectorAll("h1")
            .Select(x => x.InnerHtml)
            .First()
            .Replace("&amp;", "&");

        if (isMoreThanOneArtist)
        {
            return ReturnInfo(header);
        }

        var firstDashIndex = header.IndexOf('-');
        var titleInfo = firstDashIndex == -1 ?
            header :
            header.Substring(firstDashIndex + 2, header.Length - firstDashIndex - 2);

        return ReturnInfo(titleInfo);
    }

    internal static string GetAlbumType(IHtmlDocument htmlDocument) => htmlDocument
            .QuerySelectorAll("i")
            .Where(s => s.ClassName == "zmdi zmdi-collection-music zmdi-hc-fw")
            .Select(x => x.ParentElement!.TextContent)
            .First()
            .Trim();

    internal static List<string> GetGenres(IHtmlDocument htmlDocument) => htmlDocument
           .QuerySelectorAll("p")
           .First(p => p.ClassName == "genre__labels")
           .Children
           .Select(x => x.InnerHtml.Trim('#'))
           .ToList();

    internal static async Task<byte[]> GetAlbumCover(IHtmlDocument htmlDocument)
    {
        var coverUrl = htmlDocument.QuerySelectorAll("img")
            .First(p => p.ClassName == "album-img lozad").Attributes.First(s => s.Name == "data-src").Value;
        return await HttpClientSingleton.DownloadAsync(coverUrl);
    }


    internal static async Task<AlbumDataDto<TrackInfoDto>> GetAlbum(string url, List<ArtistDtoBase> existingArtists)
    {
        var htmlDocument = await HttpClientSingleton.GetDocumentAsync(url);

        var cover = await GetAlbumCover(htmlDocument);
        var albumTypeString = GetAlbumType(htmlDocument);
        var albumType = MusifyAlbumTypeParser.Parse(albumTypeString);
        var genres = GetGenres(htmlDocument);

        var songs = await GetTracks(htmlDocument, existingArtists);

        var artists = songs.SelectMany(x => x.Artists).DistinctBy(x => x.Name).ToList();

        var (title, yearReleased) = GetTitleAndYearReleased(htmlDocument, artists.Count > 1);

        var result = new AlbumDataDto<TrackInfoDto>
        {
            AlbumType = albumType,
            CoverData = cover,
            Genres = genres,
            Title = title,
            YearReleased = yearReleased,
            Tracks = songs,
            Url = url,
            Artists = artists
        };

        return result;
    }

    private static async Task<List<TrackInfoDto>> GetTracks(IHtmlDocument htmlDocument, List<ArtistDtoBase> existingArtists)
    {
        var result = new List<TrackInfoDto>();

        var albumContainer = htmlDocument.QuerySelectorAll("div").First(x => x.ClassName == "playlist playlist--hover");

        foreach (var trackElement in albumContainer.Children)
        {
            var songArtistLinks = trackElement
                .QuerySelectorAll("a")
                .Where(x => x.Attributes.Any(y => y.Name == "rel") && x.InnerHtml != "Flash plugin");

            var songArtists = songArtistLinks.Select(x => x.InnerHtml);

            var artists = new List<ArtistDtoBase>();
            var current = 0;

            foreach (var songArtist in songArtists)
            {
                var existingArtist = existingArtists.FirstOrDefault(x => x.Name == songArtist);

                if (existingArtist is null)
                {
                    var artistLink = songArtistLinks
                        .Select(x => CommonHelpers.WrapWithMusifySiteAddress(x.GetAttribute("href")!))
                        .ElementAt(current);

                    var artistCountry = await ArtistHelpers.GetCountry(artistLink);
                    var newArtist = new ArtistDtoBase
                    {
                        Name = songArtist,
                        Country = artistCountry,
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
                .QuerySelectorAll("a")
                .Where(s => s.ClassName == "strong")
                .First();

            var songName = songInfo.InnerHtml.Replace("&amp;", "&");

            var songLink = CommonHelpers.WrapWithMusifySiteAddress(songInfo.GetAttribute("href")!);

            var duration = trackElement.QuerySelectorAll("div")
                .Where(d => d.ClassName == "track__details hidden-xs-down" && d.FirstElementChild?.ClassName == "text-muted")
                .Select(x => x.FirstElementChild?.InnerHtml)
                .Select(TimeHelper.ToTimeSpan!)
                .First();

            var downloadUrl = trackElement.QuerySelectorAll("a")
                .Where(p => p.HasAttribute("download"))
                .Select(x => CommonHelpers.WrapWithMusifySiteAddress(x.GetAttribute("href")!))
                .FirstOrDefault();

            var track = new TrackInfoDto
            {
                Duration = duration,
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
