using PhlegmaticOne.MusifyDataApi.Core.Extensions;
using PhlegmaticOne.MusifyDataApi.Core.Models;

namespace PhlegmaticOne.MusifyDataApi.Core.Tests;

public class MusifyUrlTests
{
    [Fact]
    public void Constructor_Test()
    {
        const string url = "/top";
        Assert.Equal("https://musify.club/top", url.AsMusifyUrl().ToStringUrl());
    }
    [Fact]
    public void ToReleaseUrl_Test()
    {
        const string url = "/artist/pink-floyd-235";

        Assert.Equal("https://musify.club/artist/pink-floyd-235/releases",
            url.AsMusifyUrl().ToReleaseUrl().ToStringUrl());
    }
    [Fact]
    public void BuildSearchUrl_Test()
    {
        const string searchText = "night";
        var searchUrl = MusifyUrl.BuildSearchUrl(searchText);

        Assert.Equal("https://musify.club/search?searchText=night", searchUrl.ToStringUrl());
    }
    [Fact]
    public void BuildYearUrl_Test()
    {
        const int year = 2000;
        var yearUrl = MusifyUrl.BuildYearUrl(year);

        Assert.Equal("https://musify.club/albums/2000", yearUrl.ToStringUrl());
    }
}