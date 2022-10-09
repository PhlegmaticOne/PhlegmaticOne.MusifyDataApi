using PhlegmaticOne.MusicHttpDataApi.Musify;
using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos;
using PhlegmaticOne.MusifyDataApi.Dtos.Albums;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyArtistsData
{
    Task<OperationResult<ArtistDtoBase>> GetArtistInfoAsync(string url);
    Task<OperationResult<ArtistDataDto<AlbumInfoDto>>> GetArtistWithAlbumsInfoAsync(string url, SelectionType selectionType = SelectionType.Include, params MusifyAlbumType[] releaseTypes);
    Task<OperationResult<ArtistDataDto<AlbumDataDto<TrackInfoDto>>>> GetArtistWithAlbumsAndTracksInfoAsync(string url, SelectionType selectionType = SelectionType.Include, params MusifyAlbumType[] releaseTypes);
}