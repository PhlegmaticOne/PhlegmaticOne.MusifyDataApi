using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;

public class CommonHtmlParsersFactory : IHtmlParsersFactory
{
    private readonly Dictionary<Predicate<string>, Type> _pageParserTypes;
    private readonly IHtmlParsersFactoryConfiguration _configuration;

    public CommonHtmlParsersFactory(IHtmlParsersFactoryConfiguration configuration)
    {
        _configuration = configuration;

        _pageParserTypes = new()
        {
            { url => url.Contains(MusifyConstants.RELEASES_ACTION_NAME), FirstPageParser(typeof(IPreviewReleasesPageParser)) },
            { url => url.Contains(MusifyConstants.RELEASE_ACTION_NAME), FirstPageParser(typeof(IReleasePageParser)) },
            { url => url.Contains(MusifyConstants.ARTIST_ACTION_NAME), FirstPageParser(typeof(IArtistPageParser)) },
            { url => url.Contains(MusifyConstants.SEARCH_ACTION_NAME), FirstPageParser(typeof(ISearchPageParser)) },
        };
    }

    public async Task<TParser> GetPageParserAsync<TParser>(string url) where TParser : IHtmlPageParserBase
    {
        var parserType = _pageParserTypes.FirstOrDefault(x => x.Key(url)).Value;

        if(parserType is null)
        {
            throw new ArgumentException($"Can't find parser for url: {url}");
        }

        var parserFactory = (IHtmlPageParserBase)Activator.CreateInstance(parserType)!;
        await parserFactory.ParsePageAsync(url);

        return (TParser)parserFactory;
    }

    public TParser GetDataParser<TParser>(object htmlElement) where TParser : IHtmlDataParserBase
    {
        var dataParserType = FirstDataParser(typeof(TParser));
        if(dataParserType is null)
        {
            throw new ArgumentException($"Can't find parser for data: {htmlElement}");
        }
        var parserFactory = (IHtmlDataParserBase)Activator.CreateInstance(dataParserType)!;
        parserFactory.InitializeFromHtmlElement(htmlElement);
        return (TParser)parserFactory;
    }

    private Type FirstPageParser(Type interfaceType)
    {
        return _configuration.PageParserTypes.First(x => x.IsAssignableTo(interfaceType));
    }

    private Type FirstDataParser(Type interfaceType)
    {
        return _configuration.DataParserTypes.First(x => x.IsAssignableTo(interfaceType));
    }
}