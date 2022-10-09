namespace PhlegmaticOne.MusicHttpDataApi.Musify.Extensions;

public static class ListExtensions
{
    public static List<T> With<T>(this List<T> list, T item)
    {
        list.Add(item);
        return list;
    }
    public static List<T> With<T>(this List<T> list, IEnumerable<T> items)
    {
        list.AddRange(items);
        return list;
    }
}
