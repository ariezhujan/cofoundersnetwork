using System;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace megaswfLibrary
{
    // Bing API 2.0 code sample demonstrating the use of the
    // Image SourceType over the XML Protocol.
    public class BingImage
    {
        public static void SearchImages(string searchTerm)
        {
            searchTerm = searchTerm.Replace("_", " ");
            var items = megaswfLibrary.BingSearch.BingSearcher.SearchImages(searchTerm, null, null, null, 0, null, null, null, null, 0);
            foreach (var img in items)
            {
                Console.WriteLine(img.ContentUrl);
            }
        }
    }
}

