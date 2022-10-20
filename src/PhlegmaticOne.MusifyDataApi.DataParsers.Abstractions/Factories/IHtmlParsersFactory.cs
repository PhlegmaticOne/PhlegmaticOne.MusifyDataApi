using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;

public interface IHtmlParsersFactory
{
    Task<TParser> GetPageParserAsync<TParser>(string url) where TParser : IHtmlPageParserBase;
    TParser GetDataParser<TParser>(object htmlElement) where TParser : IHtmlDataParserBase;
}