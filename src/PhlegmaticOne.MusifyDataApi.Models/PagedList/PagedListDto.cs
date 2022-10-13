using PhlegmaticOne.MusifyDataApi.Models.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.PagedList;

public class PagedListDto<TItem>
    where TItem : OnlineDtoBase
{
    public List<TItem> Items { get; set; } = null!;
    public int PageIndex { get; set; }
}