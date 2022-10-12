using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Preview;
using PhlegmaticOne.MusifyDataApi.Models.Composite;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Default;

internal class MusifyDataSearchService : IMusifyDataSearchService
{
    public Task<OperationResult<SearchResult<ArtistPreviewDtoBase>>> SearchArtistsAsync(string searchText, int artistsCountToSelect = 5, bool includeCovers = false)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<SearchResult<ReleaseSearchPreviewDto>>> SearchReleasesAsync(string searchText, int releasesCountToSelect = 20, bool includeCovers = false)
    {
        throw new NotImplementedException();
    }
}
