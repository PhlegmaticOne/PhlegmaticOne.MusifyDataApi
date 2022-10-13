using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;
using System.Reflection;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;

public class CommonHtmlParsersFactoryConfiguration : IHtmlParsersFactoryConfiguration
{
    public CommonHtmlParsersFactoryConfiguration(Assembly parsersAssembly)
    {
        PageParserTypes = GetTypes<IHtmlPageParserBase>(parsersAssembly);
        DataParserTypes = GetTypes<IHtmlDataParserBase>(parsersAssembly);
    }
    public IList<Type> PageParserTypes { get; }
    public IList<Type> DataParserTypes { get; }

    private static IList<Type> GetTypes<T>(Assembly assembly) => assembly.GetTypes()
            .Where(x => x.IsAssignableTo(typeof(T)) && x.IsAbstract == false)
            .ToList();
}
