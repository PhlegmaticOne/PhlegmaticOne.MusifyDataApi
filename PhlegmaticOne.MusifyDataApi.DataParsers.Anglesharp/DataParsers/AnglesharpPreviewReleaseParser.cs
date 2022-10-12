using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Genres;
using PhlegmaticOne.MusifyDataApi.Models.Years;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers;

public class AnglesharpPreviewReleaseParser : IPreviewReleaseDataParser
{
    public void InitializeFromHtmlElement(object htmlElement)
    {
        throw new NotImplementedException();
    }

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

    public string GetName()
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
