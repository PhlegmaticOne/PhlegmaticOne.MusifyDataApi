using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Extensions;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Configurations;

public class InfrastructureConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public InfrastructureConfiguration(IServiceCollection serviceCollection) => 
        _serviceCollection = serviceCollection;

    public void UseDefaultInfrastructure() => 
        _serviceCollection.UseDefaultInfrastructure();

    public void UseCustomDataDownloadService<T>(
        bool addDefaultMusifyDataDownloadServiceWithThisImplementation = true) 
        where T : class, IDataDownloadService
    {
        _serviceCollection.AddScoped<IDataDownloadService, T>();

        if (addDefaultMusifyDataDownloadServiceWithThisImplementation)
        {
            _serviceCollection.AddScoped<IMusifyDataDownloadService, MusifyDataDownloadService>();
        }
    }

    public void UseCustomHtmlStringGetter<T>() where T : class, IHtmlStringGetter =>
        _serviceCollection.AddScoped<IHtmlStringGetter, T>();

    public void UseMusifyDownloadService<T>() where T : class, IMusifyDataDownloadService =>
        _serviceCollection.AddScoped<IMusifyDataDownloadService, T>();
}