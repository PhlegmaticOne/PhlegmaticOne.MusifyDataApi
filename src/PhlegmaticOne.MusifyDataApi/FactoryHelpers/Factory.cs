namespace PhlegmaticOne.MusifyDataApi.FactoryHelpers;

internal class Factory<T> : IFactory<T> where T : class
{
    private readonly Func<T> _factoryFunc;
    public Factory(Func<T> factoryFunc, Type tType)
    {
        TType = tType;
        _factoryFunc = factoryFunc;
    }

    public Type TType { get; }
    public T Create() => _factoryFunc();
}