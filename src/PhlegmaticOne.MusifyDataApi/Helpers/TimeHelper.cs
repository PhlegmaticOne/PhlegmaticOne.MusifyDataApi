namespace PhlegmaticOne.MusifyDataApi.Helpers;

internal static class TimeHelper
{
    internal static TimeSpan ToTimeSpan(string time)
    {
        var times = time.Split(':').Select(int.Parse).ToArray();
        return times.Length switch
        {
            2 => new TimeSpan(0, times[0], times[1]),
            3 => new TimeSpan(times[0], times[1], times[2]),
            _ => TimeSpan.Zero
        };
    }
}