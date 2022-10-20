using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Core;

namespace PhlegmaticOne.MusifyDataApi.Configurations.ImplementationConfigurations;

public class DefaultMusifyImplementationConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public DefaultMusifyImplementationConfiguration(IServiceCollection serviceCollection) =>
        _serviceCollection = serviceCollection;

    public void UseArtistsDataService<T>()
        where T : class, IMusifyArtistsDataService =>
        AddSingleton<IMusifyArtistsDataService, T>();

    public void UseDataSearchService<T>()
        where T : class, IMusifyDataSearchService =>
        AddSingleton<IMusifyDataSearchService, T>();

    public void UseReleasesDataService<T>()
        where T : class, IMusifyReleasesDataService =>
        AddSingleton<IMusifyReleasesDataService, T>();

    public void UseDownloadTrackService<T>()
        where T : class, IMusifyTrackDownloadService =>
        AddSingleton<IMusifyTrackDownloadService, T>();

    private void AddSingleton<TBase, TImpl>()
        where TBase : class
        where TImpl : class, TBase
    {
        _serviceCollection.AddSingleton<TBase, TImpl>();
    }
}