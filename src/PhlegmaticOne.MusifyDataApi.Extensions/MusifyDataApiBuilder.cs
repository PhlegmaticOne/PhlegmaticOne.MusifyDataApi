﻿using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Extensions.Configurations;
using PhlegmaticOne.MusifyDataApi.Extensions.Configurations.ImplementationConfigurations;

namespace PhlegmaticOne.MusifyDataApi.Extensions;

public class MusifyDataApiBuilder
{
    private readonly IServiceCollection _serviceCollection;

    public MusifyDataApiBuilder(IServiceCollection serviceCollection) => 
        _serviceCollection = serviceCollection;

    public void ConfigureImplementationWithParsers(
        Action<HtmlParsersAbstractFactoryConfiguration> htmlParsersAbstractFactoryConfigurationAction)
    {
        var htmlParsersAbstractFactoryConfiguration = 
            new HtmlParsersAbstractFactoryConfiguration(_serviceCollection);

        htmlParsersAbstractFactoryConfigurationAction(htmlParsersAbstractFactoryConfiguration);
    }

    public void ConfigureCustomApiRealizations(Action<DefaultMusifyImplementationConfiguration> dataConfigurationBuilderAction)
    {
        var musifyDataApiConfiguration = new DefaultMusifyImplementationConfiguration(_serviceCollection);
        dataConfigurationBuilderAction(musifyDataApiConfiguration);
    }

    public void ConfigureDataDownloadService(
        Action<DataDownloadingConfiguration> dataDownloadingConfigurationBuilderAction)
    {
        var configuration = new DataDownloadingConfiguration(_serviceCollection);
        dataDownloadingConfigurationBuilderAction(configuration);
    }

    public void ConfigureHtmlGetter(Action<HtmlStringGetterConfiguration> htmlStringGetterBuilderAction)
    {
        var configuration = new HtmlStringGetterConfiguration(_serviceCollection);
        htmlStringGetterBuilderAction(configuration);
    }
}