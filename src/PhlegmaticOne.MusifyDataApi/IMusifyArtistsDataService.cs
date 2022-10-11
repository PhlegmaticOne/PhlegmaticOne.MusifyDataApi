using PhlegmaticOne.MusicHttpDataApi.Musify;
using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyArtistsDataService
{
    Task<OperationResult<ArtistInfoDto>> GetArtistInfoAsync(string url, bool includeCover = false);
    Task<OperationResult<ArtistDataDto<ReleasePreviewDtoBase>>> GetArtistWithReleasePreviewInfo(string url,
        bool includeArtistCover = false, bool includeReleaseCovers = false,
        SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null);
    Task<OperationResult<ArtistDataDto<ReleaseArtistPreviewDto>>> GetArtistWithReleasePreviews(string url,
        bool includeArtistCover = false, bool includeReleaseCovers = false,
        SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null);
    Task<OperationResult<ArtistDataDto<ReleaseInfoDto>>> GetArtistWithAlbumsInfoAsync(string url,
        bool includeArtistCover = false, bool includeReleaseCovers = false,
        SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null);
    Task<OperationResult<ArtistDataDto<ReleaseDataDto<TrackInfoDto>>>> GetArtistWithAlbumsAndTracksInfoAsync(string url,
        bool includeArtistCover = false, bool includeReleaseCovers = false,
        SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null);
}