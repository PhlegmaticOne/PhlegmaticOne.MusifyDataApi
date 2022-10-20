using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Core;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Http;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Configurations;

public class HtmlStringGetterConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public HtmlStringGetterConfiguration(IServiceCollection serviceCollection) =>
        _serviceCollection = serviceCollection;

    public void UseDefaultHtmlStringGetter() => 
        _serviceCollection.AddSingleton<IHtmlStringGetter, HttpClientHtmlStringGetter>();

    public void UseCustomHtmlStringGetter<T>() where T : class, IHtmlStringGetter => 
        _serviceCollection.AddSingleton<IHtmlStringGetter, T>();
}