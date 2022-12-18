using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi;
using PhlegmaticOne.MusifyDataApi.Core;

var services = BuildServiceProvider();

await SearchSample(services.GetRequiredService<IMusifyDataSearchService>());

//await ArtistDataServiceSample(services.GetRequiredService<IMusifyArtistsDataService>());

//await ReleaseDataServiceSample(services.GetRequiredService<IMusifyReleasesDataService>());

Console.ReadLine();

static async Task ReleaseDataServiceSample(IMusifyReleasesDataService releasesDataService)
{
    const string url = "https://musify.club/release/austere-isolation-bleak-2008-203267";

    var result = await releasesDataService.GetReleaseWithTracksInfoAsync(url);
    var release = result.Result!;

    Console.WriteLine(release.Title);
    Console.WriteLine(release.YearReleased);
    Console.WriteLine(release.ReleaseType);

    Console.WriteLine(string.Join("/", release.Artists));
    Console.WriteLine();
    Console.WriteLine(string.Join("/", release.Genres));
    Console.WriteLine();
    Console.WriteLine(string.Join("\n", release.Tracks));
    Console.WriteLine();
}


static async Task ArtistDataServiceSample(IMusifyArtistsDataService artistsService)
{
    const string url = "https://musify.club/artist/austere-21896";
    var result = await artistsService.GetArtistWithReleasesAsync(url);
    var artist = result!.Result!;

    Console.WriteLine(artist.Name);
    Console.WriteLine(artist.Country);
    Console.WriteLine(artist.TracksCount);

    foreach (var releaseArtistPreviewDto in artist.Releases)
    {
        Console.WriteLine(releaseArtistPreviewDto.Title);
        Console.WriteLine(releaseArtistPreviewDto.ArtistName);
        Console.WriteLine(releaseArtistPreviewDto.YearReleased);
        Console.WriteLine(string.Join("/", releaseArtistPreviewDto.Genres));
        Console.WriteLine();
    }
}


static async Task SearchSample(IMusifyDataSearchService searchDataService)
{
    const string query = "steineiche";

    var releases = await searchDataService.SearchArtistsAsync(query, 4);

    if (releases.IsSuccess == false)
    {
        Console.WriteLine(releases.ErrorMessage);
        return;
    }

    foreach (var releaseSearchPreviewDto in releases.Result!.Items)
    {
        Console.WriteLine(releaseSearchPreviewDto.TracksCount);
        Console.WriteLine();
    }
}

static IServiceProvider BuildServiceProvider()
{
    var serviceCollection = new ServiceCollection();

    serviceCollection.AddMusifyDataApi(b =>
    {
        b.ConfigureImplementationWithParsers(p =>
        {
            p.UseDefaultHtmlParsersAbstractFactory();
            p.ConfigureUsingParsersApiRealizations(a =>
            {
                a.UseDefaultRealizations();
            });
        });
        b.ConfigureInfrastructure(p =>
        {
            p.UseDefaultInfrastructure();
        });
    });

    return serviceCollection.BuildServiceProvider();
}