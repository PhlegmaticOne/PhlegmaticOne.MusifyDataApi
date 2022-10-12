using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.Http;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

public class AnglesharpPageParserBase : IHtmlPageParserBase
{
    protected IHtmlDocument HtmlDocument = null!;
    protected static async Task<IHtmlDocument> GetHtmlPageAsync(string url)
    {
        return await HttpClientSingleton.GetDocumentAsync(url);
    }
    protected static async Task<byte[]> DownloadImageAsync(string imageUrlPart)
    {
        var imageUrl = imageUrlPart.Contains("musify") ?
            imageUrlPart : imageUrlPart.WrapWithMusifySiteAddress();
        var imageData = await HttpClientSingleton.DownloadAsync(imageUrl);
        return imageData;
    }

    public async Task ParsePageAsync(string url)
    {
        HtmlDocument = await GetHtmlPageAsync(url);
    }
}