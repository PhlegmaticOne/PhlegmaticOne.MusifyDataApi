namespace PhlegmaticOne.MusifyDataApi.Core.Downloads;

public interface IMusifyDataDownloadService
{
    Task<byte[]> DownloadAsync(string url);
}