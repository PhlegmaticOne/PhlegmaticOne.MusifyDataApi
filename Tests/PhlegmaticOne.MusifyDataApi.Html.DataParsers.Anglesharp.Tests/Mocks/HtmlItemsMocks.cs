using AngleSharp.Html.Parser;

namespace PhlegmaticOne.MusifyDataApi.Html.DataParsers.Anglesharp.Tests.Mocks;

public class HtmlItemsMocks
{
    public static object GetPreviewReleaseMockObject()
    {
        var source = @"<div data-type=""0"" class=""card release-thumbnail"">
                           <a href=""/release/pink-floyd-wish-you-were-here-1975-4863"">
                               <img class=""card-img-top lozad"" data-src=""https://37s.musify.club/img/69/8413964/22727885.jpg"" alt=""Wish You Were Here"" src=""https://37s.musify.club/img/69/8413964/22727885.jpg"" data-loaded=""true"">
                               <noscript><img src=""https://37s.musify.club/img/69/8413964/22727885.jpg"" alt=""Wish You Were Here"" /></noscript>
                           </a>
                           <div class=""card-body"">
                              <h3 class=""card-title"">
                                <a href=""/artist/pink-floyd-235"">Pink Floyd</a>
                              </h3>
                              <h4 class=""card-subtitle""><a href=""/release/pink-floyd-wish-you-were-here-1975-4863"">Wish You Were Here</a></h4>
                           </div>
                           <div class=""card-footer"">
                              <p class=""card-text""><a href=""/albums/1975"">1975</a></p>
                           </div>
                           <div class=""card-footer"">
                              <p class=""card-text genre__labels"">
                              <a href=""/genre/classic-rock-20"">Classic Rock</a><a href=""/genre/progressive-rock-53"">Progressive Rock</a><a href=""/genre/art-rock-104"">Art Rock</a>            </p>
                           </div>
                           <div class=""card-footer"">
                              <small><i class=""zmdi zmdi-calendar"" title=""Добавлено""></i> 04.09.2007</small>
                              <small><i class=""zmdi zmdi-star zmdi-hc-fw"" title=""Рейтинг""></i> 9,15</small>
                            </div>
                      </div>";
        var parser = new HtmlParser();
        var releaseItem = parser.ParseDocument(source);

        return releaseItem.QuerySelector("div")!;
    }

    public static object GetSearchReleaseMockObject()
    {
        var source = @"<div class=""contacts__item"">
                            <a href=""/release/paysage-dhiver-winterkaelte-2001-52893"" title=""Winterkaelte - 2001"">
                                <div class=""contacts__img release"">
                                    <img alt=""Winterkaelte"" data-src=""https://41s-a.musify.club/img/70/889309/40502334.jpg"" class=""lozad"" src=""https://41s-a.musify.club/img/70/889309/40502334.jpg"" data-loaded=""true"">
                                    <noscript><img src=""https://41s-a.musify.club/img/70/889309/40502334.jpg"" alt=""Winterkaelte"" /></noscript>
                                </div>
                                <div class=""contacts__info"">
                                    <strong>Winterkaelte - 2001</strong>
                                    <small>Paysage D'Hiver  </small>
                                    <small>Треков: 6</small>
                                    <small><i class=""zmdi zmdi-star zmdi-hc-fw""></i> 10,00</small>
                                </div>
                            </a>
                        </div>";
        var parser = new HtmlParser();
        var releaseItem = parser.ParseDocument(source);

        return releaseItem.QuerySelector("div")!;
    }

    public static object GetSearchArtistMockObject()
    {
        var source = @"<div class=""contacts__item"">
                            <a href=""/artist/paysage-dhiver-31910"" title=""Paysage D'Hiver"">
                                <div class=""contacts__img"">
                                    <img alt=""Paysage D'Hiver"" data-src=""https://39s.musify.club/img/69/580613/13035908.jpg"" class=""lozad"" src=""https://39s.musify.club/img/69/580613/13035908.jpg"" data-loaded=""true"">
                                    <noscript><img src=""https://39s.musify.club/img/69/580613/13035908.jpg"" alt=""Paysage D&#39;Hiver"" /></noscript>
                                </div>
                                <div class=""contacts__info"">
                                    <strong>Paysage D'Hiver</strong>
                                    <small>Треков: 80</small>
                                    <small><i class=""zmdi zmdi-star zmdi-hc-fw""></i> 20399</small>
                                </div>
                            </a>
                       </div>";
        var parser = new HtmlParser();
        var releaseItem = parser.ParseDocument(source);

        return releaseItem.QuerySelector("div")!;
    }
}