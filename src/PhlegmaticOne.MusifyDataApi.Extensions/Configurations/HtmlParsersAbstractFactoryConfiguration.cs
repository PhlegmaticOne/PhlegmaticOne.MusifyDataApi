using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Extensions.Configurations.ImplementationConfigurations;
using PhlegmaticOne.MusifyDataApi.Extensions.Factories;
using PhlegmaticOne.MusifyDataApi.Extensions.FactoryHelpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Factories;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Configurations;

public class HtmlParsersAbstractFactoryConfiguration
{
    private readonly IServiceCollection _serviceCollection;

    public HtmlParsersAbstractFactoryConfiguration(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public void UseDefaultHtmlParsersAbstractFactory()
    {
        _serviceCollection.AddSingleton<IHtmlParsersAbstractFactory, AnglesharpHtmlParsersAbstractFactory>();
    }

    public void UseCustomHtmlAbstractFactory<TFactory>() where TFactory : class, IHtmlParsersAbstractFactory
    {
        _serviceCollection.AddSingleton<IHtmlParsersAbstractFactory, TFactory>();
    }

    public void ConfigureHtmlAbstractFactory(Action<HtmlPageParsersConfiguration> pageParsersBuilderAction,
        Action<HtmlDataParsersConfiguration> dataParsersBuilderAction)
    {
        var dataParsersConfiguration = new HtmlDataParsersConfiguration(_serviceCollection);
        var pageParsersConfiguration = new HtmlPageParsersConfiguration(_serviceCollection);

        pageParsersBuilderAction(pageParsersConfiguration);
        dataParsersBuilderAction(dataParsersConfiguration);

        AddParsersFactory();
    }

    public void ConfigureUsingParsersApiRealizations(
        Action<UsingParsersMusifyImplementationConfiguration> builderAction)
    {
        var configuration = new UsingParsersMusifyImplementationConfiguration(_serviceCollection);
        builderAction(configuration);
    }

    private void AddParsersFactory()
    {
        _serviceCollection.AddSingleton<IHtmlParsersAbstractFactory, DiHtmlParsersFactory>(x =>
        {
            var dataParserFactories = x.GetServices<IFactory<IHtmlDataParserBase>>();
            var pageParserFactories = x.GetServices<IFactory<IHtmlPageParserBase>>();
            return new DiHtmlParsersFactory(pageParserFactories, dataParserFactories);
        });
    }
}