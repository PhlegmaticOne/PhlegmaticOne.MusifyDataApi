using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class ArtistParserTests
{
	private readonly IArtistPageParser _artistDataParser;
	private readonly string _artistUrl = "https://musify.club/artist/paysage-dhiver-31910";

    public ArtistParserTests()
	{
		_artistDataParser = new AnglesharpArtistPageParser();
	}

	[Fact]
	public async Task GetTracksCount_Test()
	{
		await _artistDataParser.ParsePageAsync(_artistUrl);

		var tracks = _artistDataParser.GetTracksCount();

		Assert.Equal(80, tracks);
	}

    [Fact]
    public async Task GetCountry_Test()
    {
        await _artistDataParser.ParsePageAsync(_artistUrl);

        var country = _artistDataParser.GetCountry();

        Assert.Equal("Швейцария", country);
    }

    [Fact]
    public async Task GetCover_Test()
    {
        await _artistDataParser.ParsePageAsync(_artistUrl);

        var coverData = await _artistDataParser.GetCoverAsync(true);

        Assert.NotEmpty(coverData);
    }

    [Fact]
    public async Task GetName_Test()
    {
        await _artistDataParser.ParsePageAsync(_artistUrl);

        var name = _artistDataParser.GetName();

        Assert.Equal("Paysage D'Hiver", name);
    }
}
