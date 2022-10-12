using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.DataParsers.Anglesharp.PageParsers;

public class AnglesharpPreviewReleasesPageParser : AnglesharpPageParserBase, IPreviewReleasesPageParser
{
    public IEnumerable<object> GetReleaseHtmlItems(SelectionType selectionType = SelectionType.Include,
        IEnumerable<MusifyReleaseType>? releaseTypes = null)
    {
        var albumTypes = new List<MusifyReleaseType>();
        var isInclude = selectionType == SelectionType.Include;

        if (releaseTypes is not null)
        {
            albumTypes.AddRange(releaseTypes);
        }
        else
        {
            albumTypes.AddRange(selectionType == SelectionType.Include
                ? MusifyReleaseTypesProvider.DefaultIncludeTypes
                : MusifyReleaseTypesProvider.DefaultExcludeTypes);
        }

        var proceedTypes = albumTypes.Cast<int>().Select(x => x.ToString()).ToList();

        var result = HtmlDocument
            .QuerySelectorAll("div")
            .Where(x => x.ClassName == "card release-thumbnail" &&
                proceedTypes.Contains(x.GetAttribute("data-type")!) == isInclude)
            .Cast<IHtmlDivElement>();

        return result;
    }
}
