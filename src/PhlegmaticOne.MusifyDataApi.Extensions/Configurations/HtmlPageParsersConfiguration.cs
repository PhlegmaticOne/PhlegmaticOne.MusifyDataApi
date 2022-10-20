using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Extensions.FactoryHelpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Configurations;

public class HtmlPageParsersConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public HtmlPageParsersConfiguration(IServiceCollection serviceCollection) =>
        _serviceCollection = serviceCollection;

    public HtmlPageParsersConfiguration AddPageParser<TBase, TImpl>()
        where TBase : class, IHtmlPageParserBase
        where TImpl : class, TBase
    {
        _serviceCollection.AddTransient<TBase, TImpl>();
        _serviceCollection.AddTransient<IFactory<IHtmlPageParserBase>, Factory<TBase>>(x =>
            new Factory<TBase>(x.GetRequiredService<TBase>, typeof(TBase)));
        return this;
    }
}