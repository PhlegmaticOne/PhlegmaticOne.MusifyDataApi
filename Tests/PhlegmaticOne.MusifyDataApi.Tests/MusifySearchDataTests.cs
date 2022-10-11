using Microsoft.Extensions.DependencyInjection;
using PhlegmaticOne.MusifyDataApi.Extensions;

namespace PhlegmaticOne.MusifyDataApi.Tests;

public class MusifySearchDataTests
{
    private readonly IMusifyDataSearchService _musifyDataSearch;
    public MusifySearchDataTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMusifyDataApi();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        _musifyDataSearch = serviceProvider.GetRequiredService<IMusifyDataSearchService>();
    }
    [Fact]
    public async Task Test()
    {
        var result = await _musifyDataSearch.SearchArtistsQuick("denis");
        Assert.NotNull(result);
    }
}
