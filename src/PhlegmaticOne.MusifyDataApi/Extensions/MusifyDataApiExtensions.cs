using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusicHttpDataApi.Musify.Implementation;
using PhlegmaticOne.MusifyDataApi.Implementation;

namespace PhlegmaticOne.MusifyDataApi.Extensions;

public static class MusifyDataApiExtensions
{
    public static IServiceCollection AddMusifyDataApi(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMusifyAlbumsData, MusifyAlbumsData>();
        serviceCollection.AddSingleton<IMusifyArtistsData, MusifyArtistsData>();
        return serviceCollection;
    }
}
