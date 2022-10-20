namespace PhlegmaticOne.MusifyDataApi.Html.Parsers.Core;

public interface IHtmlStringGetter
{
    Task<string> GetHtmlStringAsync(string url);
}