using PhlegmaticOne.MusifyDataApi.Core.Downloads;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.DataParsers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;
using PhlegmaticOne.MusifyDataApi.Html.Parsers.Core;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Factories;

public class AnglesharpHtmlParsersAbstractFactory : IHtmlParsersAbstractFactory
{
    private readonly IMusifyDataDownloadService _musifyDataDownloadService;
    private readonly IHtmlStringGetter _htmlStringGetter;

    private Dictionary<Type, Func<IHtmlPageParserBase>> _pageParserFactories = null!;
    private Dictionary<Type, Func<IHtmlDataParserBase>> _dataParserFactories = null!;
    public AnglesharpHtmlParsersAbstractFactory(IMusifyDataDownloadService musifyDataDownloadService,
        IHtmlStringGetter htmlStringGetter)
    {
        _musifyDataDownloadService = musifyDataDownloadService;
        _htmlStringGetter = htmlStringGetter;
        InitializeFactories();
    }

    public void InitializeFactories()
    {
        _pageParserFactories = new()
        {
            { typeof(IArtistPageParser), () =>
                new AnglesharpArtistPageParser(_htmlStringGetter, _musifyDataDownloadService) },
            { typeof(IArtistPreviewReleasesPageParser), () =>
                    new AnglesharpArtistPreviewReleasesPageParser(_htmlStringGetter) },
            { typeof(IPreviewReleasesPageParser), () =>
                new AnglesharpPreviewReleasesPageParser(_htmlStringGetter) },
            { typeof(IReleasePageParser), () =>
                new AnglesharpReleasePageParser(_htmlStringGetter, _musifyDataDownloadService) },
            { typeof(ISearchPageParser), () =>
                    new AnglesharpSearchPageParser(_htmlStringGetter) }
        };

        _dataParserFactories = new()
        {
            { typeof(IPreviewReleaseDataParser), () =>
                    new AnglesharpPreviewReleaseDataParser(_musifyDataDownloadService) },
            { typeof(ISearchArtistDataParser), () =>
                new AnglesharpSearchArtistDataParser(_musifyDataDownloadService) },
            { typeof(ISearchReleaseDataParser), () =>
                new AnglesharpSearchReleaseDataParser(_musifyDataDownloadService) }
        };
    }

    public async Task<TParser> CreatePageParserAsync<TParser>(string url)
        where TParser : IHtmlPageParserBase
    {
        var pageParser = _pageParserFactories[typeof(TParser)]();
        await pageParser.ParsePageAsync(url);
        return (TParser)pageParser;
    }

    public TParser CreateDataParser<TParser>(object htmlElement)
        where TParser : IHtmlDataParserBase
    {
        var dataParser = _dataParserFactories[typeof(TParser)]();
        dataParser.InitializeFromHtmlElement(htmlElement);
        return (TParser)dataParser;
    }
}