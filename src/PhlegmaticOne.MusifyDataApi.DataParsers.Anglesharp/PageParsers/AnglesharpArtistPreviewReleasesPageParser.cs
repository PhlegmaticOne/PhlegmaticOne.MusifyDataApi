using AngleSharp.Html.Dom;
using PhlegmaticOne.MusifyDataApi.Core.Helpers;
using PhlegmaticOne.MusifyDataApi.Html.DataParsers.Abstractions.PageParsers;
using PhlegmaticOne.MusifyDataApi.Infrastructure.Interfaces;
using PhlegmaticOne.MusifyDataApi.Models.Enums;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.PageParsers;

internal class AnglesharpArtistPreviewReleasesPageParser : AnglesharpPreviewReleasesPageParser,
    IArtistPreviewReleasesPageParser
{
    public AnglesharpArtistPreviewReleasesPageParser(IHtmlStringGetter htmlStringGetter) : base(htmlStringGetter) { }
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

        var all = base.GetReleaseHtmlItems()
            .Cast<IHtmlDivElement>()
            .Where(x => proceedTypes.Contains(x.GetAttribute("data-type")!) == isInclude);

        return all;
    }
}