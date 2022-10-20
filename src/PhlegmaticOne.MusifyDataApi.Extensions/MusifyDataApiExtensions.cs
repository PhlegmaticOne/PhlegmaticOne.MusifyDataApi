using Microsoft.Extensions.DependencyInjection;

namespace PhlegmaticOne.MusifyDataApi.Extensions;

public static class MusifyDataApiExtensions
{
    public static IServiceCollection AddMusifyDataApi(this IServiceCollection serviceCollection,
        Action<MusifyDataApiBuilder> builderAction)
    {
        var musifyDataApiBuilder = new MusifyDataApiBuilder(serviceCollection);
        builderAction(musifyDataApiBuilder);
        return serviceCollection;
    }
}