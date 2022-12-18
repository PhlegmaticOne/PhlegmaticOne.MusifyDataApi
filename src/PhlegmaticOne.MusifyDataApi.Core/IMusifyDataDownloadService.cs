namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

public interface IMusifyDataDownloadService
{
    Task<byte[]> DownloadAsync(string url);
}