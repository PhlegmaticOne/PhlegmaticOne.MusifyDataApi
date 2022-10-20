using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers.Base;

internal abstract class AnglesharpDataParserBase<TElement> : IHtmlDataParserBase
    where TElement : IHtmlElement
{
    protected TElement HtmlElement = default!;
    public void InitializeFromHtmlElement(object htmlElement)
    {
        if (htmlElement is TElement element)
        {
            HtmlElement = element;
        }
    }
}
