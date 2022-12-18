using PhlegmaticOne.MusifyDataApi.Models.Artists.Preview;
using PhlegmaticOne.MusifyDataApi.Models.Composite;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;
using PhlegmaticOne.OperationResults;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyDataSearchService
{
    Task<OperationResult<SearchResult<ArtistPreviewDtoBase>>> SearchArtistsAsync(string searchText,
        int artistsCountToSelect = 5,
        bool includeCovers = false);
    Task<OperationResult<SearchResult<ReleaseSearchPreviewDto>>> SearchReleasesAsync(string searchText,
        int releasesCountToSelect = 20,
        bool includeCovers = false);
}