using Moq;
using PhlegmaticOne.MusifyDataApi.Core.Downloads;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;

public class InterfacesMocks
{
    public static IMusifyDataDownloadService GetMusifyDataDownloadServiceMock()
    {
        var musifyDataDownloadServiceMock = new Mock<IMusifyDataDownloadService>();
        musifyDataDownloadServiceMock
            .Setup(x => x.DownloadAsync(It.IsAny<string>()))
            .ReturnsAsync(new byte[64]);
        return musifyDataDownloadServiceMock.Object;
    }
}