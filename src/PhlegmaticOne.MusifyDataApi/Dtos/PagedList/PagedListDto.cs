using PhlegmaticOne.MusicHttpDataApi.Musify.Dtos.Base;

namespace PhlegmaticOne.MusifyDataApi.Dtos.PagedList;

public class PagedListDto<TItem>
    where TItem : OnlineDtoBase
{
    public List<TItem> Items { get; init; } = null!;
    public int PageIndex { get; init; }
}