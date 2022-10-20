using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Extensions;

var serviceCollection = new ServiceCollection();

serviceCollection.AddMusifyDataApi(b =>
{
    b.UseDefaultImplementationWithParsers();
    b.ConfigureDataDownloadService(d =>
    {
        d.UseDefaultDataDownloadService();
    });
    b.ConfigureHtmlGetter(h =>
    {
        h.UseDefaultHtmlStringGetter();
    });
});

var services = serviceCollection.BuildServiceProvider();

var searchDataService = services.GetRequiredService<IMusifyDataSearchService>();


var artists = await searchDataService.SearchArtistsAsync("paysage");

foreach (var artist in artists!.Data!.Items)
{
    Console.WriteLine(artist.Name);
    Console.WriteLine(artist.TracksCount);
    Console.WriteLine();
}

Console.ReadLine();