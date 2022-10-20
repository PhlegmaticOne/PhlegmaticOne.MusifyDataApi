using PhlegmaticOne.MusifyDataApi.Core.Helpers;

namespace PhlegmaticOne.MusifyDataApi.Core.Models;

public class MusifyUrl
{
    private readonly string _url;

    public MusifyUrl(string url) => _url = TryWrapWithSiteAddress(url);

    public MusifyUrl ToReleaseUrl() => new(_url + MusifyConstants.RELEASES_ACTION_NAME);

    public static MusifyUrl BuildSearchUrl(string searchText)
    {
        var searchUrl = TryWrapWithSiteAddress(MusifyConstants.SEARCH_ACTION_NAME);
        var parametrized = searchUrl + $"?{MusifyConstants.SEARCH_TEXT_PARAMETER_NAME}={searchText}";
        return new(parametrized);
    }

    public static MusifyUrl BuildYearUrl(int year) => 
        new($"{MusifyConstants.SITE_URL}{MusifyConstants.ALBUMS_ACTION_NAME}/{year}");

    public string ToStringUrl() => _url;

    private static string TryWrapWithSiteAddress(string url) => 
        ContainsSiteUrl(url) == false ? MusifyConstants.SITE_URL + url : url;

    private static bool ContainsSiteUrl(string url) => url.Contains(MusifyConstants.SITE_URL);
}