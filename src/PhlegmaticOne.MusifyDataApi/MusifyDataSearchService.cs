using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Preview;
using PhlegmaticOne.MusifyDataApi.Models.Composite;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Default;

public class MusifyDataSearchService : IMusifyDataSearchService
{
    private readonly IHtmlParsersFactory _htmlParsersFactory;

    public MusifyDataSearchService(IHtmlParsersFactory htmlParsersFactory)
    {
        _htmlParsersFactory = htmlParsersFactory;
    }
    public async Task<OperationResult<SearchResult<ArtistPreviewDtoBase>>> SearchArtistsAsync(string searchText, 
        int artistsCountToSelect = 5, bool includeCovers = false)
    {
        var searchUrl = searchText.ToSearchUrl();
        var searchPageParser = await _htmlParsersFactory.GetPageParserAsync<ISearchPageParser>(searchUrl);

        var result = new SearchResult<ArtistPreviewDtoBase>()
        {
            Items = new List<ArtistPreviewDtoBase>()
        };

        foreach (var htmlItem in searchPageParser.GetArtistHtmlItems(artistsCountToSelect))
        {
            var artistPreviewParser = _htmlParsersFactory.GetDataParser<ISearchArtistDataParser>(htmlItem);

            var artist = new ArtistPreviewDtoBase
            {
                CoverData = await artistPreviewParser.GetCoverAsync(includeCovers),
                Name = artistPreviewParser.GetName(),
                TracksCount = artistPreviewParser.GetTracksCount(),
                Url = artistPreviewParser.GetUrl()
            };

            result.Items.Add(artist);
        }

        return OperationResult<SearchResult<ArtistPreviewDtoBase>>.FromSuccess(result);
    }

    public async Task<OperationResult<SearchResult<ReleaseSearchPreviewDto>>> SearchReleasesAsync(string searchText, 
        int releasesCountToSelect = 20, bool includeCovers = false)
    {
        var searchUrl = searchText.ToSearchUrl();
        var searchPageParser = await _htmlParsersFactory.GetPageParserAsync<ISearchPageParser>(searchUrl);

        var result = new SearchResult<ReleaseSearchPreviewDto>()
        {
            Items = new List<ReleaseSearchPreviewDto>()
        };

        foreach (var htmlItem in searchPageParser.GetReleaseHtmlItems(releasesCountToSelect))
        {
            var releasePreviewParser = _htmlParsersFactory.GetDataParser<ISearchReleaseDataParser>(htmlItem);

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

        return OperationResult<SearchResult<ReleaseSearchPreviewDto>>.FromSuccess(result);
    }
}
