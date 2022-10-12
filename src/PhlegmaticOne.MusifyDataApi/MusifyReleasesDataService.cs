using PhlegmaticOne.MusifyDataApi.Core;
using PhlegmaticOne.MusifyDataApi.Core.Results;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Releases.Direct;
using PhlegmaticOne.MusifyDataApi.Models.Tracks.Direct;

namespace PhlegmaticOne.MusifyDataApi.Default;

internal class MusifyReleasesDataService : IMusifyReleasesDataService
{
    private readonly IHtmlParsersFactory _htmlParsersFactory;

    public MusifyReleasesDataService(IHtmlParsersFactory htmlParsersFactory)
    {
        _htmlParsersFactory = htmlParsersFactory;
    }
    public async Task<OperationResult<ReleaseInfoDto>> GetReleaseInfoAsync(string url,
        bool includeCover = false)
    {
        return await OperationResult<ReleaseInfoDto>
            .FromActionResult(() => GetReleaseInfoAsyncPrivate(url, includeCover));
    }

    public async Task<OperationResult<ReleaseDataDto<TrackInfoDto>>> GetReleaseWithTracksInfoAsync(string url,
        bool includeCover = false)
    {
        return await OperationResult<ReleaseDataDto<TrackInfoDto>>.FromActionResult(() =>
            GetReleaseWithTracksInfoAsyncPrivate(url, includeCover));
    }

    private async Task<OperationResult<ReleaseInfoDto>> GetReleaseInfoAsyncPrivate(string url,
        bool includeCover = false)
    {
        var releaseParser = await _htmlParsersFactory.GetPageParserAsync<IReleasePageParser>(url);

        var result = new ReleaseInfoDto();

        await InitializeRelease(result, releaseParser, url, includeCover);

        return OperationResult<ReleaseInfoDto>.FromSuccess(result);
    }

    private async Task<OperationResult<ReleaseDataDto<TrackInfoDto>>> GetReleaseWithTracksInfoAsyncPrivate(string url,
        bool includeCover = false)
    {
        var releaseParser = await _htmlParsersFactory.GetPageParserAsync<IReleasePageParser>(url);
        var result = new ReleaseDataDto<TrackInfoDto>();
        await InitializeRelease(result, releaseParser, url, includeCover);

        var tracksEnumerable = await releaseParser.GetTracksAsync();

        result.Genres = releaseParser.GetGenres().ToList();
        result.Tracks = tracksEnumerable.ToList();
        result.Artists = result.Tracks
            .SelectMany(x => x.Artists)
            .DistinctBy(x => x.Name)
            .ToList();

        return OperationResult<ReleaseDataDto<TrackInfoDto>>.FromSuccess(result);
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
