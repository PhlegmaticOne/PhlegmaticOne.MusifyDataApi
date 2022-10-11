using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Preview;
using PhlegmaticOne.MusifyDataApi.Dtos.Composite;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyDataSearchService
{
    Task<OperationResult<SearchResult<ArtistInfoDto>>> SearchArtists(string searchText,
        int artistsCountToSelect = 5,
        bool includeCovers = false);
    Task<OperationResult<SearchResult<ArtistPreviewDtoBase>>> SearchArtistsQuick(string searchText,
        int artistsCountToSelect = 5,
        bool includeCovers = false);
    Task<OperationResult<SearchResult<ReleaseFullInfoDto>>> SearchReleasesWithFullInfo(string searchText,
        int releasesCountToSelect = 20,
        bool includeCovers = false);
    Task<OperationResult<SearchResult<ReleaseInfoDto>>> SearchReleasesWithInfo(string searchText,
        int releasesCountToSelect = 20,
        bool includeCovers = false);
    Task<OperationResult<SearchResult<ReleaseSearchPreviewDto>>> SearchReleasesQuick(string searchText,
        int releasesCountToSelect = 20,
        bool includeCovers = false);
}