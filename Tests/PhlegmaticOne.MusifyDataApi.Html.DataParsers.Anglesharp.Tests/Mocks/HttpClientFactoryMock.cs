using Moq;
using PhlegmaticOne.MusifyDataApi.Infrastructure;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;

internal static class HttpClientFactoryMock
{
    private static readonly HttpClient HttpClient = new();
    public static IHttpClientFactory ClientMock()
    {
        var mock = new Mock<IHttpClientFactory>();
        mock.Setup(x => x.CreateClient(HttpClientConstants.ServerName))
            .Returns(HttpClient);
        return mock.Object;
    }
}