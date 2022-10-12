namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;

public interface IHtmlPageParserBase
{
    Task ParsePageAsync(string url);
}