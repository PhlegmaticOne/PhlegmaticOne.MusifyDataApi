using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos;
using PhlegmaticOne.MusifyDataApi.Dtos.Albums;

namespace PhlegmaticOne.MusifyDataApi;

public interface IMusifyAlbumsData
{
    Task<OperationResult<AlbumInfoDto>> GetAlbumInfoAsync(string url);
    Task<OperationResult<AlbumDataDto<TrackInfoDto>>> GetAlbumWithTracksInfoAsync(string url);
    Task<OperationResult<AlbumDataDto<TrackDataDto>>> GetAlbumWithTracksDataAsync(string url);
}