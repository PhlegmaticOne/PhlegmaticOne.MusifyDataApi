using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;

public interface IHtmlParsersFactory
{
    Task<TParser> GetPageParserAsync<TParser>(string url) where TParser : IHtmlPageParserBase;
    TParser GetDataParser<TParser>(object htmlElement) where TParser : IHtmlDataParserBase;
}