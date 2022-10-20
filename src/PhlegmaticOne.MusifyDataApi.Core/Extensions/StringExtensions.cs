using PhlegmaticOne.MusifyDataApi.Core.Models;

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

    public static MusifyUrl AsMusifyUrl(this string url) => new(url);
}