namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

public interface IHtmlStringGetter
{
    Task<string> GetHtmlStringAsync(string url);
}