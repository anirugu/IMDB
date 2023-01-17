using AngleSharp;
using AngleSharp.Browser;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace IMDB
{
    public class IMDBSearch : IIMDBSearch
    {
        private readonly IHtmlDocument _document;
        private readonly IHtmlParser _parser;

        public IMDBSearch(string html) : this()
        {
            _document = _parser.ParseDocumentAsync(html).Result;
        }

        public IMDBSearch(Stream html) : this()
        {
            _document = _parser.ParseDocumentAsync(html).Result;
        }

        public IMDBSearch()
        {
            _parser = new HtmlParser();
        }

        public IEnumerable<string> GetShortCodes()
        {
            var anchors = _document.QuerySelectorAll(".lister-item-header a[href]").Select(x => x.Attributes["href"].Value.Split("/")[2]);
            return anchors;
        }

        public IEnumerable<string> GetTVCodes()
        {
            return _document.QuerySelectorAll(".lister-item-year.text-muted.unbold").Where(x => x.TextContent.IndexOf("–") > 0)
                   .Select(
                       elem =>
                       {
                           if (elem.NextElementSibling == null)
                           {
                               return elem.PreviousElementSibling.Attributes["href"].Value.Split("/")[4];
                           }
                           else
                           {
                               return elem.PreviousElementSibling.Attributes["href"].Value.Split("/")[4];
                           }
                       });
        }
    }
}