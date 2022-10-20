using Moq;
using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.Default.Tests.Mocks;

public class ParsersMocksCollection
{
    public static void SetupHtmlParsersFactoryWithPageParser<T>(Mock<IHtmlParsersAbstractFactory> htmlParsersFactoryMock, 
        T pageParser) where T : IHtmlPageParserBase
    {
        htmlParsersFactoryMock
            .Setup(x => x.CreatePageParserAsync<T>(It.IsAny<string>()))
            .ReturnsAsync(pageParser);
    }

    public static void SetupHtmlParsersFactoryWithDataParser<T>(Mock<IHtmlParsersAbstractFactory> htmlParsersFactoryMock,
        T dataParser) where T : IHtmlDataParserBase
    {
        htmlParsersFactoryMock
            .Setup(x => x.CreateDataParser<T>(It.IsAny<object>()))
            .Returns(dataParser);
    }

    public static IArtistPageParser GetArtistPageParserMock(string artistName, string country, int tracksCount,
        int coverDataLength)
    {
        var artistPageParserMock = new Mock<IArtistPageParser>();

        artistPageParserMock.Setup(x => x.GetName()).Returns(artistName);
        artistPageParserMock.Setup(x => x.GetTracksCount()).Returns(tracksCount);
        artistPageParserMock.Setup(x => x.GetCoverAsync(It.IsAny<bool>()))
            .ReturnsAsync(new byte[coverDataLength]);
        artistPageParserMock.Setup(x => x.GetCountry()).Returns(country);

        return artistPageParserMock.Object;
    }

    public static IArtistPreviewReleasesPageParser GetArtistPreviewReleasesPageParserMock(int releasesCount)
    {
        var artistPreviewReleasesPageParserMock = new Mock<IArtistPreviewReleasesPageParser>();

        artistPreviewReleasesPageParserMock
            .Setup(x => x.GetReleaseHtmlItems(It.IsAny<SelectionType>(), It.IsAny<IEnumerable<MusifyReleaseType>>()))
            .Returns(Enumerable.Repeat(new object(), releasesCount));

        return artistPreviewReleasesPageParserMock.Object;
    }

    public static IPreviewReleaseDataParser GetPreviewReleaseDataParser(string title, int year,
        string url, int coverDataLength,
        IEnumerable<string> artists, IEnumerable<string> genres)
    {
        var previewReleaseDataParser = new Mock<IPreviewReleaseDataParser>();


        previewReleaseDataParser
            .Setup(x => x.InitializeFromHtmlElement(It.IsAny<object>()));

        previewReleaseDataParser
            .Setup(x => x.GetTitle())
            .Returns(title);

        previewReleaseDataParser
            .Setup(x => x.GetUrl())
            .Returns(url);

        previewReleaseDataParser.Setup(x => x.GetYear())
            .Returns(new YearDtoBase
            {
                HasValue = true,
                YearReleased = year
            });

        previewReleaseDataParser
            .Setup(x => x.GetCoverAsync(It.IsAny<bool>()))
            .ReturnsAsync(new byte[coverDataLength]);

        previewReleaseDataParser
            .Setup(x => x.GetArtists())
            .Returns(artists.Select(x => new ArtistDtoBase() { Name = x }));

        previewReleaseDataParser
            .Setup(x => x.GetGenres())
            .Returns(genres.Select(x => new GenreDto(){ Name = x }));


        return previewReleaseDataParser.Object;
    }

    public static ISearchPageParser GetSearchPageParser(int releasesCount, int artistsCount)
    {
        var searchPageParserMock = new Mock<ISearchPageParser>();

        searchPageParserMock
            .Setup(x => x.GetArtistHtmlItems(It.IsAny<int>()))
            .Returns(Enumerable.Repeat(new object(), artistsCount));
        searchPageParserMock
            .Setup(x => x.GetReleaseHtmlItems(It.IsAny<int>()))
            .Returns(Enumerable.Repeat(new object(), releasesCount));

        return searchPageParserMock.Object;
    }

    public static ISearchArtistDataParser GetSearchArtistDataParser(string name, int tracksCount,
        string url, int coverDataLength)
    {
        var searchArtistDataParserMock = new Mock<ISearchArtistDataParser>();

        searchArtistDataParserMock
            .Setup(x => x.GetCoverAsync(It.IsAny<bool>()))
            .ReturnsAsync(new byte[coverDataLength]);
        searchArtistDataParserMock
            .Setup(x => x.GetName())
            .Returns(name);
        searchArtistDataParserMock
            .Setup(x => x.GetTracksCount())
            .Returns(tracksCount);
        searchArtistDataParserMock
            .Setup(x => x.GetUrl())
            .Returns(url);

        return searchArtistDataParserMock.Object;
    }

    public static ISearchReleaseDataParser GetSearchReleaseDataParser(string title,
        string artistName, string url, int tracksCount, int year, int coverDataLength)
    {
        var searchReleaseDataParser = new Mock<ISearchReleaseDataParser>();

        searchReleaseDataParser
            .Setup(x => x.GetTitle())
            .Returns(title);
        searchReleaseDataParser
            .Setup(x => x.GetArtistName())
            .Returns(artistName);
        searchReleaseDataParser
            .Setup(x => x.GetCoverAsync(It.IsAny<bool>()))
            .ReturnsAsync(new byte[coverDataLength]);
        searchReleaseDataParser
            .Setup(x => x.GetTracksCount())
            .Returns(tracksCount);
        searchReleaseDataParser
            .Setup(x => x.GetUrl())
            .Returns(url);
        searchReleaseDataParser
            .Setup(x => x.GetYear())
            .Returns(new YearDtoBase
            {
                HasValue = true,
                YearReleased = year
            });

        return searchReleaseDataParser.Object;
    }

    public static IReleasePageParser GetReleasePageParser(string title,
        MusifyReleaseType releaseType, int year, int coverDataLength,
        IEnumerable<string> genres, IEnumerable<(string, string)> tracks)
    {
        var releasePageParserMock = new Mock<IReleasePageParser>();

        releasePageParserMock
            .Setup(x => x.GetTitle())
            .Returns(title);
        releasePageParserMock
            .Setup(x => x.GetReleaseType())
            .Returns(releaseType);
        releasePageParserMock.Setup(x => x.GetYear())
            .Returns(new YearDtoBase
            {
                HasValue = true,
                YearReleased = year
            });
        releasePageParserMock.Setup(x => x.GetReleaseCoverAsync(It.IsAny<bool>()))
            .ReturnsAsync(new byte[coverDataLength]);
        releasePageParserMock
            .Setup(x => x.GetGenres())
            .Returns(genres.Select(x => new GenreDto() { Name = x }));
        releasePageParserMock
            .Setup(x => x.GetTracks())
            .Returns(tracks.Select(x => new TrackInfoDto()
            {
                Title = x.Item1,
                Artists = new List<ArtistDtoBase>()
                {
                    new(){ Name = x.Item2}
                }
            }));

        return releasePageParserMock.Object;
    }
}