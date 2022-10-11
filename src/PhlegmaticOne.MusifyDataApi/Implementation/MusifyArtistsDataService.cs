using PhlegmaticOne.MusicHttpDataApi.Musify;
using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Dtos.Releases.Preview;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Implementation;

internal class MusifyArtistsDataService : IMusifyArtistsDataService
{
    public Task<OperationResult<ArtistInfoDto>> GetArtistInfoAsync(string url, bool includeCover = false)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<ArtistDataDto<ReleaseDataDto<TrackInfoDto>>>> GetArtistWithAlbumsAndTracksInfoAsync(string url, bool includeArtistCover = false, bool includeReleaseCovers = false, SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<ArtistDataDto<ReleaseInfoDto>>> GetArtistWithAlbumsInfoAsync(string url, bool includeArtistCover = false, bool includeReleaseCovers = false, SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<ArtistDataDto<ReleasePreviewDtoBase>>> GetArtistWithReleasePreviewInfo(string url, bool includeArtistCover = false, bool includeReleaseCovers = false, SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<ArtistDataDto<ReleaseArtistPreviewDto>>> GetArtistWithReleasePreviews(string url, bool includeArtistCover = false, bool includeReleaseCovers = false, SelectionType selectionType = SelectionType.Include, IEnumerable<MusifyAlbumType>? releaseTypes = null)
    {
        throw new NotImplementedException();
    }
}
