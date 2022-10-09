using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Enums;
using PhlegmaticOne.MusicHttpDataApi.Musify.Helpers.Html;
using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi;
using PhlegmaticOne.MusifyDataApi.Dtos;
using PhlegmaticOne.MusifyDataApi.Dtos.Albums;
using PhlegmaticOne.MusifyDataApi.Dtos.Artists;
using PhlegmaticOne.MusifyDataApi.Helpers.Html;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusicHttpDataApi.Musify.Implementation;

internal class MusifyArtistsData : IMusifyArtistsData
{
    private readonly IMusifyAlbumsData _musifyAlbumsData;
    public MusifyArtistsData(IMusifyAlbumsData musifyAlbumsData) => _musifyAlbumsData = musifyAlbumsData;

    public async Task<OperationResult<ArtistDtoBase>> GetArtistInfoAsync(string url)
    {
        try
        {
            var document = await HttpClientSingleton.GetDocumentAsync(url);
            var country = ArtistHelpers.GetCountry(document);
            var name = ArtistHelpers.GetName(document);

            return OperationResult<ArtistDtoBase>.FromSuccess(new()
            {
                Name = name,
                Country = country,
                Url = url
            });
        }
        catch (Exception ex)
        {
            return OperationResult<ArtistDtoBase>.FromException(ex);
        }
    }
    public async Task<OperationResult<ArtistDataDto<AlbumInfoDto>>> GetArtistWithAlbumsInfoAsync(string url, SelectionType selectionType = SelectionType.Include, params MusifyAlbumType[] releaseTypes)
    {
        try
        {
            var artistInfo = await GetArtistInfoAsync(url);
            var albumUrls = await ArtistHelpers.GetAlbumUrls(url, selectionType, releaseTypes);
            var result = ArtistHelpers.GetArtistResult<AlbumInfoDto>(artistInfo.Data!, url);

            foreach (var albumUrl in albumUrls)
            {
                var albumInfo = await _musifyAlbumsData.GetAlbumInfoAsync(albumUrl);
                result.Releases.Add(albumInfo.Data!);
            }

            result.Releases.Sort((x, y) => x.YearReleased.CompareTo(y.YearReleased));

            return OperationResult<ArtistDataDto<AlbumInfoDto>>.FromSuccess(result);
        }
        catch (Exception ex)
        {
            return OperationResult<ArtistDataDto<AlbumInfoDto>>.FromException(ex);
        }
    }

    public async Task<OperationResult<ArtistDataDto<AlbumDataDto<TrackInfoDto>>>> GetArtistWithAlbumsAndTracksInfoAsync(string url, SelectionType selectionType = SelectionType.Include, params MusifyAlbumType[] releaseTypes)
    {
        try
        {
            var artistInfoResult = await GetArtistInfoAsync(url);
            var artistInfo = artistInfoResult.Data!;
            var albumUrls = await ArtistHelpers.GetAlbumUrls(url, selectionType, releaseTypes);
            var result = ArtistHelpers.GetArtistResult<AlbumDataDto<TrackInfoDto>>(artistInfo, url);

            var existingArtists = new List<ArtistDtoBase>() { artistInfo };

            foreach (var albumUrl in albumUrls)
            {
                var albumInfo = await AlbumHelpers.GetAlbum(albumUrl, existingArtists);
                result.Releases.Add(albumInfo);
            }

            result.Releases.Sort((x, y) => x.YearReleased.CompareTo(y.YearReleased));

            return OperationResult<ArtistDataDto<AlbumDataDto<TrackInfoDto>>>.FromSuccess(result);
        }
        catch (Exception ex)
        {
            return OperationResult<ArtistDataDto<AlbumDataDto<TrackInfoDto>>>.FromException(ex);
        }
    }
}
