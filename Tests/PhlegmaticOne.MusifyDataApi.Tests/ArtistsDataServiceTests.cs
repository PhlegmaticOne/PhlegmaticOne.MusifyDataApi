using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Default;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class ArtistsDataServiceTests
{
    private readonly IMusifyArtistsDataService _artistsDataService;
    private readonly string _artistUrl = "https://musify.club/artist/paysage-dhiver-31910";

    public ArtistsDataServiceTests()
    {
        var parsersConfiguration = new CommonHtmlParsersFactoryConfiguration(typeof(AnglesharpReleasePageParser).Assembly);
        var parsersFactory = new CommonHtmlParsersFactory(parsersConfiguration);
        _artistsDataService = new MusifyArtistsDataService(parsersFactory);
    }

    [Fact]
    public async Task GetArtistInfo_Test()
    {
        var artistInfo = await _artistsDataService.GetArtistInfoAsync(_artistUrl);

        Assert.NotNull(artistInfo);
    }

    [Fact]
    public async Task GetArtistInfoWithReleases_Test()
    {
        var artistInfo = await _artistsDataService.GetArtistWithReleases(_artistUrl);

        Assert.NotNull(artistInfo);
    }
}