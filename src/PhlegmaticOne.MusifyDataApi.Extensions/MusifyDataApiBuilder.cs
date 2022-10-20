using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Default;
using PhlegmaticOne.MusifyDataApi.Extensions.Configurations;
using PhlegmaticOne.MusifyDataApi.Extensions.Factories;
using PhlegmaticOne.MusifyDataApi.Extensions.FactoryHelpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;

namespace PhlegmaticOne.MusifyDataApi.Extensions;

public class MusifyDataApiBuilder
{
    private readonly IServiceCollection _serviceCollection;

    public MusifyDataApiBuilder(IServiceCollection serviceCollection) => 
        _serviceCollection = serviceCollection;

    public void UseDefaultImplementationWithParsers()
    {
        UseImplementationWithCustomParsers(b =>
        {
            b.AddPageParser<IArtistPageParser, AnglesharpArtistPageParser>()
             .AddPageParser<IArtistPreviewReleasesPageParser, AnglesharpArtistPreviewReleasesPageParser>()
             .AddPageParser<IPreviewReleasesPageParser, AnglesharpPreviewReleasesPageParser>()
             .AddPageParser<IReleasePageParser, AnglesharpReleasePageParser>()
             .AddPageParser<ISearchPageParser, AnglesharpSearchPageParser>();
        },
            b =>
        {
            b.AddDataParser<IPreviewReleaseDataParser, AnglesharpPreviewReleaseDataParser>()
             .AddDataParser<ISearchArtistDataParser, AnglesharpSearchArtistDataParser>()
             .AddDataParser<ISearchReleaseDataParser, AnglesharpSearchReleaseDataParser>();
        });
    }

    public void UseImplementationWithCustomParsers(Action<HtmlPageParsersConfiguration> pageParsersBuilderAction,
        Action<HtmlDataParsersConfiguration> dataParsersBuilderAction)
    {
        var dataParsersConfiguration = new HtmlDataParsersConfiguration(_serviceCollection);
        var pageParsersConfiguration = new HtmlPageParsersConfiguration(_serviceCollection);

        pageParsersBuilderAction(pageParsersConfiguration);
        dataParsersBuilderAction(dataParsersConfiguration);

        ConfigureApiRealizations(b =>
        {
            b.UseArtistsDataService<MusifyArtistsDataService>();
            b.UseDataSearchService<MusifyDataSearchService>();
            b.UseDownloadTrackService<MusifyTrackDownloadService>();
            b.UseReleasesDataService<MusifyReleasesDataService>();
        });

        AddParsersFactory();
    }

    public void ConfigureApiRealizations(Action<MusifyDataApiConfiguration> dataConfigurationBuilderAction)
    {
        var musifyDataApiConfiguration = new MusifyDataApiConfiguration(_serviceCollection);
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

    private void AddParsersFactory()
    {
        _serviceCollection.AddSingleton<IHtmlParsersFactory, DiHtmlParsersFactory>(x =>
        {
            var dataParserFactories = x.GetServices<IFactory<IHtmlDataParserBase>>();
            var pageParserFactories = x.GetServices<IFactory<IHtmlPageParserBase>>();
            return new DiHtmlParsersFactory(pageParserFactories, dataParserFactories);
        });
    }
}