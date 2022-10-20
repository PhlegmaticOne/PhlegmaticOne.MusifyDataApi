using PhlegmaticOne.MusifyDataApi.Extensions.FactoryHelpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;

namespace PhlegmaticOne.MusifyDataApi.Extensions.Factories;

internal class DiHtmlParsersFactory : IHtmlParsersAbstractFactory
{
    private readonly List<IFactory<IHtmlPageParserBase>> _pageParsers;
    private readonly List<IFactory<IHtmlDataParserBase>> _dataParsers;

    public DiHtmlParsersFactory(IEnumerable<IFactory<IHtmlPageParserBase>> pageParsers, 
        IEnumerable<IFactory<IHtmlDataParserBase>> dataParsers)
    {
        _pageParsers = pageParsers.ToList();
        _dataParsers = dataParsers.ToList();
    }

    public void InitializeFactories() { }

    public async Task<TParser> CreatePageParserAsync<TParser>(string url) where TParser : IHtmlPageParserBase
    {
        var parser = _pageParsers
            .First(x => x.TType == typeof(TParser))
            .Create();

        await parser.ParsePageAsync(url);
        return (TParser)parser;
    }

    public TParser CreateDataParser<TParser>(object htmlElement) where TParser : IHtmlDataParserBase
    {
        var dataParser = _dataParsers
            .First(x => x.TType == typeof(TParser))
            .Create();

        dataParser.InitializeFromHtmlElement(htmlElement);
        return (TParser)dataParser;
    }
}