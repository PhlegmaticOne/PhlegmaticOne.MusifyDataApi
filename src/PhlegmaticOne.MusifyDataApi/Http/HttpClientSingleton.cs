using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace PhlegmaticOne.MusifyDataApi.Http;

internal class HttpClientSingleton
{
    private static readonly Lazy<HttpClient> _lazy = new(() => new(), true);
    private HttpClientSingleton() { }
    public static HttpClient Instance => _lazy.Value;
    internal static async Task<IHtmlDocument> GetDocumentAsync(string url)
    {
        var source = await Instance.GetStringAsync(url);
        var parser = new HtmlParser();
        var domDocument = await parser.ParseDocumentAsync(source);
        return domDocument;
    }
    internal static async Task<byte[]> DownloadAsync(string url)
    {
        var songBytes = await Instance.GetByteArrayAsync(url);
        return songBytes;
    }
}