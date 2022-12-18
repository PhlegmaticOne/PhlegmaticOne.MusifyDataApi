namespace PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;

public interface IDataDownloadService
{
    Task<byte[]> DownloadAsync(string downloadUrl);
}