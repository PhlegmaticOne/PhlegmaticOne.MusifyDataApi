namespace PhlegmaticOne.MusifyDataApi.Core.Results;

public class OperationResult<T> where T : class
{
    public T? Data { get; init; }
    public bool IsOk { get; init; }
    public Exception? ExceptionThrown { get; init; }
    public OperationResult(T? data, bool isOk, Exception? exceptionThrown = null)
    {
        Data = data;
        IsOk = isOk;
        ExceptionThrown = exceptionThrown;
    }
    public static OperationResult<T> FromException(Exception exception) =>
        new(null, false, exception);
    public static OperationResult<T> FromSuccess(T data) =>
        new(data, true);

    public static async Task<OperationResult<T>> FromActionResult(Func<Task<OperationResult<T>>> operation)
    {
        try
        {
            return await operation();
        }
        catch (Exception ex)
        {
            return FromException(ex);
        }
    }
}
