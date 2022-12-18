using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Implementation.Parsers;

namespace PhlegmaticOne.MusifyDataApi.Configurations.ImplementationConfigurations;

public class UsingParsersMusifyImplementationConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public UsingParsersMusifyImplementationConfiguration(IServiceCollection serviceCollection) =>
        _serviceCollection = serviceCollection;

    public void UseArtistsDataService<T>()
        where T : class, IMusifyArtistsDataService, IUseHtmlParsers =>
        AddScoped<IMusifyArtistsDataService, T>();

    public void UseDataSearchService<T>()
        where T : class, IMusifyDataSearchService, IUseHtmlParsers =>
        AddScoped<IMusifyDataSearchService, T>();

    public void UseReleasesDataService<T>()
        where T : class, IMusifyReleasesDataService, IUseHtmlParsers =>
        AddScoped<IMusifyReleasesDataService, T>();

    public void UseDownloadTrackService<T>()
        where T : class, IMusifyTrackDownloadService, IUseHtmlParsers =>
        AddScoped<IMusifyTrackDownloadService, T>();


    public void UseDefaultRealizations()
    {
        UseArtistsDataService<MusifyArtistsDataService>();
        UseDataSearchService<MusifyDataSearchService>();
        UseDownloadTrackService<MusifyTrackDownloadService>();
        UseReleasesDataService<MusifyReleasesDataService>();
    }

    private void AddScoped<TBase, TImpl>()
        where TBase : class
        where TImpl : class, TBase
    {
        _serviceCollection.AddScoped<TBase, TImpl>();
    }
}