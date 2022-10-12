using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Default;

internal class MusifyArtistsDataService : IMusifyArtistsDataService
{
    private readonly IHtmlParsersFactory _htmlParsersFactory;

    public MusifyArtistsDataService(IHtmlParsersFactory htmlParsersFactory)
    {
        _htmlParsersFactory = htmlParsersFactory;
    }

    public async Task<OperationResult<ArtistInfoDto>> GetArtistInfoAsync(string url,
        bool includeCover = false)
    {
        var artistParser = await _htmlParsersFactory.GetPageParserAsync<IArtistPageParser>(url);
        var result = new ArtistInfoDto
        {
            CoverData = await artistParser.GetCoverAsync(includeCover),
            TracksCount = artistParser.GetTracksCount(),
            Url = url,
            Country = artistParser.GetCountry(),
            Name = artistParser.GetName()
        };
        return OperationResult<ArtistInfoDto>.FromSuccess(result);
    }

    public async Task<OperationResult<ArtistDataDto<ReleaseArtistPreviewDto>>> GetArtistWithReleases(
        string url, bool includeArtistCover = false, bool includeReleaseCovers = false,
        SelectionType selectionType = SelectionType.Include,
        IEnumerable<MusifyReleaseType>? releaseTypes = null)
    {
        var releasesParser = await _htmlParsersFactory.GetPageParserAsync<IPreviewReleasesPageParser>(url);
        var releasesElements = releasesParser.GetReleaseHtmlItems(selectionType, releaseTypes);
        foreach (var releaseElement in releasesElements)
        {

        }
        return OperationResult<ArtistDataDto<ReleaseArtistPreviewDto>>.FromSuccess(null);
    }
}
