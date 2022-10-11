using PhlegmaticOne.MusicHttpDataApi.Musify.Results;
using PhlegmaticOne.MusifyDataApi.Categories;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Base;
using PhlegmaticOne.MusifyDataApi.Dtos.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Implementation;

internal class MusifyTracksPagedListDataService : IMusifyTracksPagedListDataService
{
    public Task<OperationResult<TrackDtoBase>> GetTracks(int pageIndex, ISearchCategoryString searchCategoryString)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<TrackInfoDto>> GetTracksInfo(int pageIndex, ISearchCategoryString searchCategoryString)
    {
        throw new NotImplementedException();
    }
}
