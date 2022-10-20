namespace PhlegmaticOne.MusifyDataApi.DataDownload.Http.Tests;

public class HttpClientDataDownloadTests
{
    private readonly HttpClientDataDownloadService _dataDownloadService;
    public HttpClientDataDownloadTests() =>
        _dataDownloadService = new HttpClientDataDownloadService();

    [Fact]
    public async Task DownloadAsync_ShouldReturnData_Image_Test()
    {
        const string url = "https://41s-a.musify.club/img/71/15002531/38041162.jpg";
        var data = await _dataDownloadService.DownloadAsync(url);
        Assert.NotEmpty(data);
    }

    [Fact]
    public async Task DownloadAsync_ShouldReturnData_Track_Test()
    {
        const string url = "https://musify.club/track/dl/635420/paysage-dhiver-atmosphaere.mp3";
        var data = await _dataDownloadService.DownloadAsync(url);
        Assert.NotEmpty(data);
    }

    [Fact]
    public async Task DownloadAsync_ShouldThrowException_InvalidUrl_Test()
    {
        const string url = "https://41s-a.musify.club/img/71/15002531/38041162";
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
            await _dataDownloadService.DownloadAsync(url));
    }
}