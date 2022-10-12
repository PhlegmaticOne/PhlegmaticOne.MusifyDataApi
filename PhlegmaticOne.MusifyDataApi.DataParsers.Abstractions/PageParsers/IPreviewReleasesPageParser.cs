using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;

public interface IPreviewReleasesPageParser : IHtmlPageParserBase
{
    IEnumerable<object> GetReleaseHtmlItems(SelectionType selectionType = SelectionType.Include,
        IEnumerable<MusifyReleaseType>? releaseTypes = null);
}