using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Http;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.Downloads;

public class MusifyImageDownloader
{
    public static async Task<byte[]> DownloadImageAsync(string imageUrlPart)
    {
        var imageUrl = imageUrlPart.Contains(MusifyConstants.SITE_NAME) ?
            imageUrlPart : imageUrlPart.WrapWithMusifySiteAddress();
        var imageData = await HttpClientSingleton.Instance.GetByteArrayAsync(imageUrl);
        return imageData;
    }
}
