using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;

public interface IHtmlParsersAbstractFactory
{
    Task<TParser> CreatePageParserAsync<TParser>(string url) where TParser : IHtmlPageParserBase;
    TParser CreateDataParser<TParser>(object htmlElement) where TParser : IHtmlDataParserBase;
}