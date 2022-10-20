using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Core;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Configurations;

public class MusifyDataApiConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public MusifyDataApiConfiguration(IServiceCollection serviceCollection) =>
        _serviceCollection = serviceCollection;

    public MusifyDataApiConfiguration UseArtistsDataService<T>() where T : class, IMusifyArtistsDataService =>
        AddSingleton<IMusifyArtistsDataService, T>();

    public MusifyDataApiConfiguration UseDataSearchService<T>() where T : class, IMusifyDataSearchService =>
        AddSingleton<IMusifyDataSearchService, T>();

    public MusifyDataApiConfiguration UseReleasesDataService<T>() where T : class, IMusifyReleasesDataService =>
        AddSingleton<IMusifyReleasesDataService, T>();

    public MusifyDataApiConfiguration UseDownloadTrackService<T>() where T : class, IMusifyTrackDownloadService =>
        AddSingleton<IMusifyTrackDownloadService, T>();

    private MusifyDataApiConfiguration AddSingleton<TBase, TImpl>()
        where TBase : class
        where TImpl : class, TBase
    {
        _serviceCollection.AddSingleton<TBase, TImpl>();
        return this;
    }
}