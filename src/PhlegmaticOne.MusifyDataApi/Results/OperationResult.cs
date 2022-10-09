namespace PhlegmaticOne.MusicHttpDataApi.Musify.Results;

public class OperationResult<T> where T : class
{
    public T? Data { get; init; }
    public bool IsOk { get; init; }
    public Exception? ExceptionThrowed { get; init; }
    public OperationResult(T? data, bool isOk, Exception? exceptionThrowed = null)
    {
        Data = data;
        IsOk = isOk;
        ExceptionThrowed = exceptionThrowed;
    }
    internal static OperationResult<T> FromException(Exception exception) =>
        new(null, false, exception);
    internal static OperationResult<T> FromSuccess(T data) =>
        new(data, true);
}
