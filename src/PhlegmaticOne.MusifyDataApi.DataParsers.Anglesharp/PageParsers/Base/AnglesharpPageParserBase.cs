using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers.Base;

internal abstract class AnglesharpPageParserBase : IHtmlPageParserBase
{
    private readonly IHtmlStringGetter _htmlStringGetter;

    protected IHtmlDocument HtmlDocument = null!;

    protected AnglesharpPageParserBase(IHtmlStringGetter htmlStringGetter) =>
        _htmlStringGetter = htmlStringGetter;

    public async Task ParsePageAsync(string url) =>
        HtmlDocument = await GetHtmlPageAsync(url);

    protected async Task<IHtmlDocument> GetHtmlPageAsync(string url)
    {
        var source = await _htmlStringGetter.GetHtmlStringAsync(url);
        var parser = new HtmlParser();
        var domDocument = await parser.ParseDocumentAsync(source);
        return domDocument;
    }
}