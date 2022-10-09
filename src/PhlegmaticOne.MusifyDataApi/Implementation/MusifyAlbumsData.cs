using PhlegmaticOne.MusicHttpDataApi.Musify.Helpers;
using PhlegmaticOne.MusicHttpDataApi.Musify.Helpers.Html;
using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Dtos;
using PhlegmaticOne.MusifyDataApi.Dtos.Albums;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusifyDataApi.Implementation;

internal class MusifyAlbumsData : IMusifyAlbumsData
{
    public async Task<OperationResult<AlbumInfoDto>> GetAlbumInfoAsync(string url)
    {
        try
        {
            var domDocument = await HttpClientSingleton.GetDocumentAsync(url);
            var isMoreThanOneArtist = AlbumHelpers.IsMoreThanOneArtistCheck(domDocument);
            var albumTypeString = AlbumHelpers.GetAlbumType(domDocument);
            var albumType = MusifyAlbumTypeParser.Parse(albumTypeString);
            var (title, year) = AlbumHelpers.GetTitleAndYearReleased(domDocument, isMoreThanOneArtist);

            return OperationResult<AlbumInfoDto>.FromSuccess(new()
            {
                AlbumType = albumType,
                Title = title,
                YearReleased = year,
                Url = url
            });
        }
        catch (Exception ex)
        {
            return OperationResult<AlbumInfoDto>.FromException(ex);
        }
    }

    public async Task<OperationResult<AlbumDataDto<TrackInfoDto>>> GetAlbumWithTracksInfoAsync(string url)
    {
        try
        {
            var result = await AlbumHelpers.GetAlbum(url, new List<ArtistDtoBase>());

            return OperationResult<AlbumDataDto<TrackInfoDto>>.FromSuccess(result);
        }
        catch (Exception ex)
        {
            return OperationResult<AlbumDataDto<TrackInfoDto>>.FromException(ex);
        }
    }

    public async Task<OperationResult<AlbumDataDto<TrackDataDto>>> GetAlbumWithTracksDataAsync(string url)
    {
        try
        {
            var albumResult = await GetAlbumWithTracksInfoAsync(url);
            var album = albumResult.Data!;
            var tracks = new List<TrackDataDto>();
            foreach (var trackInfo in album.Tracks)
            {
                var data = await HttpClientSingleton.DownloadAsync(trackInfo.DownloadUrl);
                tracks.Add(new()
                {
                    Artists = trackInfo.Artists,
                    DownloadUrl = trackInfo.DownloadUrl,
                    Duration = trackInfo.Duration,
                    Title = trackInfo.Title,
                    Url = trackInfo.Url,
                    TrackData = data
                });
            }

            return OperationResult<AlbumDataDto<TrackDataDto>>.FromSuccess(new()
            {
                YearReleased = album.YearReleased,
                Title = album.Title,
                Genres = album.Genres,
                Artists = album.Artists,
                AlbumType = album.AlbumType,
                Tracks = tracks,
                CoverData = album.CoverData,
                Url = album.Url,
            });
        }
        catch (Exception ex)
        {
            return OperationResult<AlbumDataDto<TrackDataDto>>.FromException(ex);
        }
    }
}
