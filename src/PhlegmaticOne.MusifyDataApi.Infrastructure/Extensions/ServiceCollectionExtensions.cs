using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Implementation;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseDefaultInfrastructure(this IServiceCollection services, TimeSpan requestExecutionTimeout)
    {
        services.AddHttpClient(HttpClientConstants.ServerName, client =>
        {
            client.Timeout = requestExecutionTimeout;
        });
        services.AddScoped<IHtmlStringGetter, HttpClientHtmlStringGetter>();
        services.AddScoped<IDataDownloadService, HttpClientDataDownloadService>();
        services.AddScoped<IMusifyDataDownloadService, MusifyDataDownloadService>();
        return services;
    }
}