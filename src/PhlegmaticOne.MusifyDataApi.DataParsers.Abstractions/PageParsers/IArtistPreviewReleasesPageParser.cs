using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.Base;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;

public interface IArtistPreviewReleasesPageParser : IHtmlPageParserBase
{
    IEnumerable<object> GetReleaseHtmlItems(SelectionType selectionType = SelectionType.Include,
        IEnumerable<MusifyReleaseType>? releaseTypes = null);
}