using PhlegmaticOne.MusifyDataApi.Core.Results;

namespace PhlegmaticOne.MusifyDataApi.Core.Tests;

public class OperationResultTests
{
    [Fact]
    public void FromSuccess_ShouldContainData_Test()
    {
        var result = OperationResult<string>.FromSuccess("data");

        Assert.Null(result.ExceptionThrown);
        Assert.True(result.IsOk);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public void FromException_ShouldNotContainData_Test()
    {
        var result = OperationResult<string>.FromException(new InvalidCastException());

        Assert.NotNull(result.ExceptionThrown);
        Assert.IsType<InvalidCastException>(result.ExceptionThrown);
        Assert.False(result.IsOk);
        Assert.Null(result.Data);
    }

    [Fact]
    public async Task FromOperationResult_ShouldContainData_Test()
    {
        var result = await OperationResult<string>
            .FromActionResult(() => Task.FromResult(new string("")));

        Assert.Null(result.ExceptionThrown);
        Assert.True(result.IsOk);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task FromOperationResult_ShouldNotContainData_Test()
    {
        var result = await OperationResult<string>
            .FromActionResult(() => throw new InvalidCastException());

        Assert.NotNull(result.ExceptionThrown);
        Assert.IsType<InvalidCastException>(result.ExceptionThrown);
        Assert.False(result.IsOk);
        Assert.Null(result.Data);
    }
}