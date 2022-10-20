using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Core.Downloads;
using PhlegmaticOne.MusifyDataApi.DataDownload.Core;
using PhlegmaticOne.MusifyDataApi.DataDownload.Http;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Configurations;

public class DataDownloadingConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public DataDownloadingConfiguration(IServiceCollection serviceCollection) => 
        _serviceCollection = serviceCollection;

    public void UseDefaultDataDownloadService()
    {
        _serviceCollection.AddSingleton<IDataDownloadService, HttpClientDataDownloadService>();
        AddMusifyDownloadService();
    }

    public void UseCustomDataDownloadService<T>() where T : class, IDataDownloadService
    {
        _serviceCollection.AddSingleton<IDataDownloadService, T>();
        AddMusifyDownloadService();
    }

    private void AddMusifyDownloadService() => 
        _serviceCollection.AddSingleton<IMusifyDataDownloadService, MusifyDataDownloadService>();
}