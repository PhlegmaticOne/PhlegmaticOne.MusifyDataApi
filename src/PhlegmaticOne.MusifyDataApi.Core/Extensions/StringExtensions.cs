using PhlegmaticOne.MusifyDataApi.Core.Helpers;

namespace PhlegmaticOne.MusifyDataApi.Core.Extensions;

public static class StringExtensions
{
    public static TimeSpan ToTimeSpan(this string source)
    {
        var times = source.Split(':').Select(int.Parse).ToArray();
        return times.Length switch
        {
            2 => new TimeSpan(0, times[0], times[1]),
            3 => new TimeSpan(times[0], times[1], times[2]),
            _ => TimeSpan.Zero
        };
    }

    public static string WrapWithMusifySiteAddress(this string value) =>
        MusifyConstants.SITE_URL + value;
    public static string ToReleaseUrl(this string url) => url + MusifyConstants.RELEASES_ACTION_NAME;
    public static string ToYearUrl(this int year) =>
        $"{MusifyConstants.SITE_URL}{MusifyConstants.ALBUMS_ACTION_NAME}/{year}";
    public static string ToSearchUrl(this string searchText) =>
        WrapWithMusifySiteAddress(MusifyConstants.SEARCH_ACTION_NAME) +
        $"?{MusifyConstants.SEARCH_TEXT_PARAMETER_NAME}={searchText}";
}