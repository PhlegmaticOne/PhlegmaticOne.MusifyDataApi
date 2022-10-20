using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Extensions.FactoryHelpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Configurations;

public class HtmlDataParsersConfiguration
{
    private readonly IServiceCollection _serviceCollection;
    public HtmlDataParsersConfiguration(IServiceCollection serviceCollection) =>
        _serviceCollection = serviceCollection;

    public HtmlDataParsersConfiguration AddDataParser<TBase, TImpl>()
        where TBase : class, IHtmlDataParserBase
        where TImpl : class, TBase
    {
        _serviceCollection.AddTransient<TBase, TImpl>();
        _serviceCollection.AddTransient<IFactory<IHtmlDataParserBase>, Factory<TBase>>(x =>
            new Factory<TBase>(x.GetRequiredService<TBase>, typeof(TBase)));
        return this;
    }
}