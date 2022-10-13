using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Default;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class ReleasesDataServiceTests
{
    private readonly IMusifyReleasesDataService _releaseDataService;
    private readonly string _releaseUrl = "https://musify.club/release/vinterriket-and-paysage-dhiver-2003-205226";

    public ReleasesDataServiceTests()
    {
        var parsersConfiguration = new CommonHtmlParsersFactoryConfiguration(typeof(AnglesharpReleasePageParser).Assembly);
        var parsersFactory = new CommonHtmlParsersFactory(parsersConfiguration);
        _releaseDataService = new MusifyReleasesDataService(parsersFactory);
    }
    [Fact]
    public async Task GetReleaseInfo_Test()
    {
        var releaseUrls = new List<string>
        {
            "https://musify.club/release/vinterriket-and-paysage-dhiver-2003-205226",
            "https://musify.club/release/paysage-dhiver-das-tor-2013-367186",
            "https://musify.club/release/paysage-dhiver-einsamkeit-2007-52903",
            "https://musify.club/release/paysage-dhiver-kerker-1999-52885",
            "https://musify.club/release/paysage-dhiver-steineiche-1998-52880"
        };

        foreach (var releaseUrl in releaseUrls)
        {
            var release = await _releaseDataService.GetReleaseInfoAsync(releaseUrl, true);
            Assert.NotNull(release.Data);
        }
    }

    [Fact]
    public async Task Parallel_GetReleaseInfo_Test()
    {
        var releaseUrls = new List<string>
        {
            "https://musify.club/release/vinterriket-and-paysage-dhiver-2003-205226",
            "https://musify.club/release/paysage-dhiver-das-tor-2013-367186",
            "https://musify.club/release/paysage-dhiver-einsamkeit-2007-52903",
            "https://musify.club/release/paysage-dhiver-kerker-1999-52885",
            "https://musify.club/release/paysage-dhiver-steineiche-1998-52880"
        };

        await Parallel.ForEachAsync(releaseUrls, async (url, token) =>
        {
            var release = await _releaseDataService.GetReleaseInfoAsync(url, true);
            Assert.NotNull(release.Data);
        });
    }
}