using System.Web;

namespace PhlegmaticOne.MusifyDataApi.Html.Parsers.Http.Tests;

public class HtmlStringGetterTests
{
    private readonly HttpClientHtmlStringGetter _htmlStringGetter;

    public HtmlStringGetterTests() => _htmlStringGetter = new();

    [Fact]
    public async Task GetHtmlStringAsync_ShouldReturnHtml_Test()
    {
        const string url = "https://musify.club/top";
        var html = await _htmlStringGetter.GetHtmlStringAsync(url);

        Assert.NotEmpty(html);
        Assert.NotEqual(html, HttpUtility.HtmlEncode(html));
    }

    [Fact]
    public async Task GetHtmlStringAsync_ShouldThrowException_InvalidUrl_Test()
    {
        const string url = "https://aaaa.club/top";

        await Assert.ThrowsAsync<HttpRequestException>(async () =>
            await _htmlStringGetter.GetHtmlStringAsync(url));
    }
}