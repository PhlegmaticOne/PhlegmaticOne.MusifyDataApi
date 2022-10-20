using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Implementation.Parsers;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Configurations.ImplementationConfigurations;

public class UsingParsersMusifyImplementationConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public UsingParsersMusifyImplementationConfiguration(IServiceCollection serviceCollection) =>
        _serviceCollection = serviceCollection;

    public void UseArtistsDataService<T>()
        where T : class, IMusifyArtistsDataService, IUseHtmlParsers =>
        AddSingleton<IMusifyArtistsDataService, T>();

    public void UseDataSearchService<T>()
        where T : class, IMusifyDataSearchService, IUseHtmlParsers =>
        AddSingleton<IMusifyDataSearchService, T>();

    public void UseReleasesDataService<T>()
        where T : class, IMusifyReleasesDataService, IUseHtmlParsers =>
        AddSingleton<IMusifyReleasesDataService, T>();

    public void UseDownloadTrackService<T>()
        where T : class, IMusifyTrackDownloadService, IUseHtmlParsers =>
        AddSingleton<IMusifyTrackDownloadService, T>();


    public void UseDefaultRealizations()
    {
        UseArtistsDataService<MusifyArtistsDataService>();
        UseDataSearchService<MusifyDataSearchService>();
        UseDownloadTrackService<MusifyTrackDownloadService>();
        UseReleasesDataService<MusifyReleasesDataService>();
    }

    private void AddSingleton<TBase, TImpl>()
        where TBase : class
        where TImpl : class, TBase
    {
        _serviceCollection.AddSingleton<TBase, TImpl>();
    }
}