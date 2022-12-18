using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Configurations;
using PhlegmaticOne.MusifyDataApi.Configurations.ImplementationConfigurations;

namespace PhlegmaticOne.MusifyDataApi;

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

    public void ConfigureInfrastructure(
        Action<InfrastructureConfiguration> infrastructureConfigurationBuilderAction)
    {
        var infrastructure = new InfrastructureConfiguration(_serviceCollection);
        infrastructureConfigurationBuilderAction(infrastructure);
    }
}