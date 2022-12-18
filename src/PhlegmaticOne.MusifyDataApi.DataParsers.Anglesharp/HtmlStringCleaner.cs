namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp;

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