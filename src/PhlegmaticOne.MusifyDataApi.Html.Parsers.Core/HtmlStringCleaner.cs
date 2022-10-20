namespace PhlegmaticOne.MusifyDataApi.Html.Parsers.Core;

public class HtmlStringCleaner
{
    public static string ClearString(string str)
    {
        return str.Replace("\n", "")
                .Replace("&amp;", "&")
                .Replace("&gt;", ">")
                .Replace("&lt;", "<")
                .Trim();
    }
}