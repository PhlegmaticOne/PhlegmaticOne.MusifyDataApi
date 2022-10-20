using Moq;
using PhlegmaticOne.MusifyDataApi.Core.Downloads;
using PhlegmaticOne.MusifyDataApi.Models.Artists.Base;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Implementation.Parsers.Tests;

public class MusifyTrackDownloadServiceTests
{
    private readonly MusifyTrackDownloadService _musifyTrackDownloadService;
    public MusifyTrackDownloadServiceTests()
    {
        var downloadService = GetMusifyDataDownloadServiceMock();
        _musifyTrackDownloadService = new MusifyTrackDownloadService(downloadService);
    }

    [Fact]
    public async Task DownloadTrackAsync_Test()
    {
        var track = new TrackInfoDto
        {
            Title = "Title",
            Url = "Url",
            Artists = new List<ArtistDtoBase> { new() { Name = "Name" } },
            DownloadUrl = "DownloadUrl",
            Duration = TimeSpan.FromMinutes(3)
        };
        var result = await _musifyTrackDownloadService.DownloadTrackAsync(track);
        var downloadedTrack = result!.Data!;
        Assert.Equal(track.DownloadUrl, downloadedTrack.DownloadUrl);
        Assert.Equal(track.Duration, downloadedTrack.Duration);
        Assert.Equal(track.Artists, downloadedTrack.Artists);
        Assert.Equal(track.Title, downloadedTrack.Title);
        Assert.Equal(track.Url, downloadedTrack.Url);
        Assert.Equal(64, downloadedTrack.TrackData.Length);
    }

    private static IMusifyDataDownloadService GetMusifyDataDownloadServiceMock()
    {
        var musifyDataDownloadServiceMock = new Mock<IMusifyDataDownloadService>();
        musifyDataDownloadServiceMock
            .Setup(x => x.DownloadAsync(It.IsAny<string>()))
            .ReturnsAsync(new byte[64]);
        return musifyDataDownloadServiceMock.Object;
    }
}