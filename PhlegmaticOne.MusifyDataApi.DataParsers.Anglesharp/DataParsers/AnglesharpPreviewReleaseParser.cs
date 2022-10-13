using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers.Base;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers;

public class AnglesharpPreviewReleaseParser : AnglesharpDataParserBase<IHtmlDivElement>, IPreviewReleaseDataParser
{
    public Task<byte[]> GetCoverAsync(bool includeCover)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<GenreDto> GetGenres()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ArtistDtoBase> GetArtists()
    {
        throw new NotImplementedException();
    }

    public string GetTitle()
    {
        throw new NotImplementedException();
    }

    public YearDtoBase GetYear()
    {
        throw new NotImplementedException();
    }

    public string GetUrl()
    {
        throw new NotImplementedException();
    }
}
