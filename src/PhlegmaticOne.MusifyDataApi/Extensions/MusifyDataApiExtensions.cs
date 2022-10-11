using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Implementation;

namespace PhlegmaticOne.MusifyDataApi.Extensions;

public static class MusifyDataApiExtensions
{
    public static IServiceCollection AddMusifyDataApi(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMusifyArtistsDataService, MusifyArtistsDataService>();
        serviceCollection.AddSingleton<IMusifyDataSearchService, MusifyDataSearchService>();
        serviceCollection.AddSingleton<IMusifyDownloadDataService, MusifyDownloadDataService>();
        serviceCollection.AddSingleton<IMusifyReleasesDataService, MusifyReleasesDataService>();
        serviceCollection.AddSingleton<IMusifyReleasesPagedListDataService, MusifyReleasesPagedListDataService>();
        serviceCollection.AddSingleton<IMusifyTracksPagedListDataService, MusifyTracksPagedListDataService>();
        return serviceCollection;
    }
}
