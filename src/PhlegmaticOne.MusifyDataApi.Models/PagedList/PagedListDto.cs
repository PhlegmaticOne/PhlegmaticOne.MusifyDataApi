using PhlegmaticOne.MusifyDataApi.Models.Base;

namespace PhlegmaticOne.MusifyDataApi.Models.PagedList;

public class PagedListDto<TItem>
    where TItem : OnlineDtoBase
{
    public List<TItem> Items { get; set; } = null!;
    public int PageIndex { get; set; }
    public override string ToString() => $"Items count: {Items.Count}. Page Index: {PageIndex}";
}