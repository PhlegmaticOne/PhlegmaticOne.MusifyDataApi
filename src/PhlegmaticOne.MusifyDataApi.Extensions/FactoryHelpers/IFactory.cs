namespace PhlegmaticOne.MusifyDataApi.Extensions.FactoryHelpers;

public interface IFactory<out T> where T : class
{
    Type TType { get; }

    T Create();
}