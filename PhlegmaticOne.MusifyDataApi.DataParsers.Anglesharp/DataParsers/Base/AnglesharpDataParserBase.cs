using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.DataParsers.Base;

public abstract class AnglesharpDataParserBase<TElement> : IHtmlDataParserBase
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
