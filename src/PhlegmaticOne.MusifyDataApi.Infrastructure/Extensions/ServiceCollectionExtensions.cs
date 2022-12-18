using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseDefaultInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient(HttpClientConstants.ServerName, client =>
        {
            client.Timeout = TimeSpan.FromSeconds(15);
        });
        services.AddScoped<IHtmlStringGetter, HttpClientHtmlStringGetter>();
        services.AddScoped<IDataDownloadService, HttpClientDataDownloadService>();
        services.AddSingleton<IMusifyDataDownloadService, MusifyDataDownloadService>();
        return services;
    }
}