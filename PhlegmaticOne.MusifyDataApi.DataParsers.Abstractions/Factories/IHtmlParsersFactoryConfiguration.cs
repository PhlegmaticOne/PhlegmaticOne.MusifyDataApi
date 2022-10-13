namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Factories;

public interface IHtmlParsersFactoryConfiguration
{
    public IList<Type> PageParserTypes { get; }
    public IList<Type> DataParserTypes { get; }
}