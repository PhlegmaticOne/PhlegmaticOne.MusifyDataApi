namespace PhlegmaticOne.MusifyDataApi.Helpers.Html;

internal static class CommonHelpers
{
    internal static string WrapWithMusifySiteAddress(string value) =>
        "https://musify.club" + value;
    internal static string ToReleaseUrl(string url) => url + "/releases";
}
