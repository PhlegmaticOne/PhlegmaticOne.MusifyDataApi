using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;

public interface IPreviewReleaseDataParser : IHtmlDataParserBase
{
    Task<byte[]> GetCoverAsync(bool includeCover);
    IEnumerable<GenreDto> GetGenres();
    IEnumerable<ArtistDtoBase> GetArtists();
    string GetName();
    YearDtoBase GetYear();
    string GetUrl();
}