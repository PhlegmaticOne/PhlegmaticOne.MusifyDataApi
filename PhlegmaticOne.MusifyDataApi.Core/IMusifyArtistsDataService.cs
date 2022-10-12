using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Preview;

namespace PhlegmaticOne.MusifyDataApi.Core;

public interface IMusifyArtistsDataService
{
    Task<OperationResult<ArtistInfoDto>> GetArtistInfoAsync(string url, bool includeCover = false);
    Task<OperationResult<ArtistDataDto<ReleaseArtistPreviewDto>>> GetArtistWithReleases(string url,
        bool includeArtistCover = false, bool includeReleaseCovers = false,
        SelectionType selectionType = SelectionType.Include,
        IEnumerable<MusifyReleaseType>? releaseTypes = null);
}