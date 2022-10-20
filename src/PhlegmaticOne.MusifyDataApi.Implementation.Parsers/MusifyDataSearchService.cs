using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Models;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Preview;
using PhlegmaticOne.MusifyDataApi.Models.Composite;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Implementation.Parsers;

public class MusifyDataSearchService : IMusifyDataSearchService, IUseHtmlParsers
{
    private readonly IHtmlParsersAbstractFactory _htmlParsersFactory;

    public MusifyDataSearchService(IHtmlParsersAbstractFactory htmlParsersFactory) =>
        _htmlParsersFactory = htmlParsersFactory;

    public async Task<OperationResult<SearchResult<ArtistPreviewDtoBase>>> SearchArtistsAsync(string searchText,
        int artistsCountToSelect = 5, bool includeCovers = false) =>
        await OperationResult<SearchResult<ArtistPreviewDtoBase>>.FromActionResult(() =>
            SearchArtistsAsyncPrivate(searchText, artistsCountToSelect, includeCovers));

    public async Task<OperationResult<SearchResult<ReleaseSearchPreviewDto>>> SearchReleasesAsync(string searchText,
        int releasesCountToSelect = 20, bool includeCovers = false) =>
        await OperationResult<SearchResult<ReleaseSearchPreviewDto>>.FromActionResult(() =>
            SearchReleasesAsyncPrivate(searchText, releasesCountToSelect, includeCovers));

    private async Task<SearchResult<ReleaseSearchPreviewDto>> SearchReleasesAsyncPrivate(string searchText,
        int releasesCountToSelect = 20, bool includeCovers = false)
    {
        var searchUrl = MusifyUrl.BuildSearchUrl(searchText).ToStringUrl();
        var searchPageParser = await _htmlParsersFactory.CreatePageParserAsync<ISearchPageParser>(searchUrl);

        var result = new SearchResult<ReleaseSearchPreviewDto>()
        {
            Items = new List<ReleaseSearchPreviewDto>()
        };

        foreach (var htmlItem in searchPageParser.GetReleaseHtmlItems(releasesCountToSelect))
        {
            var releasePreviewParser = _htmlParsersFactory.CreateDataParser<ISearchReleaseDataParser>(htmlItem);

            var artist = new ReleaseSearchPreviewDto
            {
                ArtistName = releasePreviewParser.GetArtistName(),
                Title = releasePreviewParser.GetTitle(),
                YearReleased = releasePreviewParser.GetYear(),
                CoverData = await releasePreviewParser.GetCoverAsync(includeCovers),
                TracksCount = releasePreviewParser.GetTracksCount(),
                Url = releasePreviewParser.GetUrl()
            };

            result.Items.Add(artist);
        }

        return result;
    }

    private async Task<SearchResult<ArtistPreviewDtoBase>> SearchArtistsAsyncPrivate(string searchText,
        int artistsCountToSelect = 5, bool includeCovers = false)
    {
        var searchUrl = MusifyUrl.BuildSearchUrl(searchText).ToStringUrl();
        var searchPageParser = await _htmlParsersFactory.CreatePageParserAsync<ISearchPageParser>(searchUrl);

        var result = new SearchResult<ArtistPreviewDtoBase>()
        {
            Items = new List<ArtistPreviewDtoBase>()
        };

        foreach (var htmlItem in searchPageParser.GetArtistHtmlItems(artistsCountToSelect))
        {
            var artistPreviewParser = _htmlParsersFactory.CreateDataParser<ISearchArtistDataParser>(htmlItem);

            var artist = new ArtistPreviewDtoBase
            {
                CoverData = await artistPreviewParser.GetCoverAsync(includeCovers),
                Name = artistPreviewParser.GetName(),
                TracksCount = artistPreviewParser.GetTracksCount(),
                Url = artistPreviewParser.GetUrl()
            };

            result.Items.Add(artist);
        }

        return result;
    }
}
