using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Default;

public class MusifyReleasesDataService : IMusifyReleasesDataService
{
    private readonly IHtmlParsersFactory _htmlParsersFactory;

    public MusifyReleasesDataService(IHtmlParsersFactory htmlParsersFactory) => 
        _htmlParsersFactory = htmlParsersFactory;

    public async Task<OperationResult<ReleaseInfoDto>> GetReleaseInfoAsync(string url, bool includeCover = false) =>
        await OperationResult<ReleaseInfoDto>
            .FromActionResult(() => GetReleaseInfoAsyncPrivate(url, includeCover));

    public async Task<OperationResult<ReleaseDataDto<TrackInfoDto>>> GetReleaseWithTracksInfoAsync(string url, bool includeCover = false) =>
        await OperationResult<ReleaseDataDto<TrackInfoDto>>.FromActionResult(() =>
            GetReleaseWithTracksInfoAsyncPrivate(url, includeCover));

    private async Task<ReleaseInfoDto> GetReleaseInfoAsyncPrivate(string url,
        bool includeCover = false)
    {
        var releaseParser = await _htmlParsersFactory.GetPageParserAsync<IReleasePageParser>(url);

        var result = new ReleaseInfoDto();

        await InitializeRelease(result, releaseParser, url, includeCover);

        return result;
    }

    private async Task<ReleaseDataDto<TrackInfoDto>> GetReleaseWithTracksInfoAsyncPrivate(string url,
        bool includeCover = false)
    {
        var releaseParser = await _htmlParsersFactory.GetPageParserAsync<IReleasePageParser>(url);
        var result = new ReleaseDataDto<TrackInfoDto>();
        await InitializeRelease(result, releaseParser, url, includeCover);

        var tracksEnumerable = releaseParser.GetTracks();

        result.Genres = releaseParser.GetGenres().ToList();
        result.Tracks = tracksEnumerable.ToList();
        result.Artists = result.Tracks
            .SelectMany(x => x.Artists)
            .DistinctBy(x => x.Name)
            .ToList();

        return result;
    }

    private static async Task InitializeRelease<TRelease>(TRelease releaseDto,
        IReleasePageParser releaseParser, string url, bool includeCover)
        where TRelease : ReleaseInfoDto
    {
        releaseDto.CoverData = await releaseParser.GetReleaseCoverAsync(includeCover);
        releaseDto.ReleaseType = releaseParser.GetReleaseType();
        releaseDto.Title = releaseParser.GetTitle();
        releaseDto.YearReleased = releaseParser.GetYear();
        releaseDto.Url = url;
    }
}
