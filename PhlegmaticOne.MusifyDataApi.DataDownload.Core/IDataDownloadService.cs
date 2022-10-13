namespace PhlegmaticOne.MusifyDataApi.DataDownload.Core;

public interface IDataDownloadService
{
    Task<byte[]> DownloadAsync(string downloadUrl);
}