using PhlegmaticOne.MusifyDataApi.Html.Parsers.Core;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusifyDataApi.Html.Parsers.Http;

public class HttpClientHtmlStringGetter : IHtmlStringGetter
{
    public async Task<string> GetHtmlStringAsync(string url)
    {
        var source = await HttpClientSingleton.Instance.GetStringAsync(url);
        return source;
    }
}