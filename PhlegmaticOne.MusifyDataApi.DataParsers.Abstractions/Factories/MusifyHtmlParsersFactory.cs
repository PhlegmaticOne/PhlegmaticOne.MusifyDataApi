using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;

public class MusifyHtmlParsersFactory : IHtmlParsersFactory
{
    private readonly Type _releaseParserType;
    private readonly Type _artistParserType;

    public MusifyHtmlParsersFactory(Type releaseParserType, Type artistParserType)
    {
        _releaseParserType = releaseParserType;
        _artistParserType = artistParserType;
    }

    public async Task<TParser> GetPageParserAsync<TParser>(string url) where TParser : IHtmlPageParserBase
    {
        IHtmlPageParserBase? parserFactory = default;

        if (url.Contains(MusifyConstants.RELEASE_ACTION_NAME))
        {
            parserFactory = (IHtmlPageParserBase)Activator.CreateInstance(_releaseParserType)!;
        }
        if (url.Contains(MusifyConstants.ARTIST_ACTION_NAME))
        {
            parserFactory = (IHtmlPageParserBase)Activator.CreateInstance(_artistParserType)!;
        }

        if(parserFactory is null)
        {
            throw new ArgumentException($"Can't find parser for url: {url}");
        }

        await parserFactory.ParsePageAsync(url);

        return (TParser)parserFactory;
    }

    public TParser GetDataParser<TParser>(object htmlElement) where TParser : IHtmlDataParserBase
    {
        var parserFactory = (IHtmlDataParserBase)Activator.CreateInstance(typeof(TParser))!;
        parserFactory.InitializeFromHtmlElement(htmlElement);
        return (TParser)parserFactory;
    }
}