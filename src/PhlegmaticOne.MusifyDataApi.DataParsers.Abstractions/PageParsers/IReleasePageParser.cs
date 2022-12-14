using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Models.Enums;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;

public interface IReleasePageParser : IHtmlPageParserBase
{
    string GetTitle();
    YearDtoBase GetYear();
    MusifyReleaseType GetReleaseType();
    IEnumerable<GenreDto> GetGenres();
    Task<byte[]> GetReleaseCoverAsync(bool includeCover);
    IEnumerable<TrackInfoDto> GetTracks();
}