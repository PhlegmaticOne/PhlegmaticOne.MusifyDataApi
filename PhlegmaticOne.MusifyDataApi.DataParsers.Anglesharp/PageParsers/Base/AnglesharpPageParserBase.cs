using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers.Base;

public abstract class AnglesharpPageParserBase : IHtmlPageParserBase
{
    protected IHtmlDocument HtmlDocument = null!;

    public async Task ParsePageAsync(string url) =>
        HtmlDocument = await GetHtmlPageAsync(url);

    protected static async Task<IHtmlDocument> GetHtmlPageAsync(string url)
    {
        var source = await HttpClientSingleton.Instance.GetStringAsync(url);
        var parser = new HtmlParser();
        var domDocument = await parser.ParseDocumentAsync(source);
        return domDocument;
    }
}