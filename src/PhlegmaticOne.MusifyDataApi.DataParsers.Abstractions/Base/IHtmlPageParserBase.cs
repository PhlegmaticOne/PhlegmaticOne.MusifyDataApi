namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;

public interface IHtmlPageParserBase
{
    Task ParsePageAsync(string url);
}