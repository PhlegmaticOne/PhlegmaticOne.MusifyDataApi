using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Implementation.Parsers;

public class MusifyArtistsDataService : IMusifyArtistsDataService, IUseHtmlParsers
{
    private readonly IHtmlParsersAbstractFactory _htmlParsersFactory;

    public MusifyArtistsDataService(IHtmlParsersAbstractFactory htmlParsersFactory) => 
        _htmlParsersFactory = htmlParsersFactory;

    public async Task<OperationResult<ArtistInfoDto>> GetArtistInfoAsync(string url, bool includeCover = false) =>
        await OperationResult<ArtistInfoDto>.FromActionResult(() =>
            GetArtistInfoAsyncPrivate<ArtistInfoDto>(url, includeCover));

    public async Task<OperationResult<ArtistDataDto<ReleaseArtistPreviewDto>>> GetArtistWithReleasesAsync(
        string url, bool includeArtistCover = false, bool includeReleaseCovers = false,
            SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyReleaseType>? releaseTypes = null) =>
                await OperationResult<ArtistDataDto<ReleaseArtistPreviewDto>>.FromActionResult(() => 
                    GetArtistWithReleasesPrivate(url, includeArtistCover, includeReleaseCovers, selectionType));

    private async Task<ArtistDataDto<ReleaseArtistPreviewDto>> GetArtistWithReleasesPrivate(
        string url, bool includeArtistCover = false, bool includeReleaseCovers = false,
        SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyReleaseType>? releaseTypes = null)
    {
        var releasesUrl = url.AsMusifyUrl().ToReleaseUrl().ToStringUrl();
        var releasesParser = await _htmlParsersFactory
            .CreatePageParserAsync<IArtistPreviewReleasesPageParser>(releasesUrl);
        var releasesElements = releasesParser
            .GetReleaseHtmlItems(selectionType, releaseTypes);

        var artistInfoResult = await GetArtistInfoAsyncPrivate<ArtistDataDto<ReleaseArtistPreviewDto>>(url, includeArtistCover);
        artistInfoResult.Releases = new();

        foreach (var releaseElement in releasesElements)
        {
            var releaseParser = _htmlParsersFactory.CreateDataParser<IPreviewReleaseDataParser>(releaseElement);
            var releaseDto = new ReleaseArtistPreviewDto
            {
                ArtistName = artistInfoResult.Name,
                CoverData = await releaseParser.GetCoverAsync(includeReleaseCovers),
                Genres = releaseParser.GetGenres().ToList(),
                Title = releaseParser.GetTitle(),
                Url = releaseParser.GetUrl(),
                YearReleased = releaseParser.GetYear()
            };
            artistInfoResult.Releases.Add(releaseDto);
        }

        return artistInfoResult;
    }

    private async Task<T> GetArtistInfoAsyncPrivate<T>(string url,
        bool includeCover = false) where T : ArtistInfoDto, new()
    {
        var artistParser = await _htmlParsersFactory.CreatePageParserAsync<IArtistPageParser>(url);
        var result = new T
        {
            CoverData = await artistParser.GetCoverAsync(includeCover),
            TracksCount = artistParser.GetTracksCount(),
            Url = url,
            Country = artistParser.GetCountry(),
            Name = artistParser.GetName()
        };
        return result;
    }
}
