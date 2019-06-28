using System;

namespace QuantumLibrary.BingSearch
{
    public class BinqImageItem
    {
        public string Name { get; set; }
        public string WebSearchUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime DatePublished { get; set; }
        public string ContentUrl { get; set; }
        public string HostPageUrl { get; set; }
        public string ContentSize { get; set; }
        public string EncodingFormat { get; set; }
        public string HostPageDisplayUrl { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double ThumbnailWidth { get; set; }
        public double ThumbnailHeight { get; set; }

        public BinqImageItem() { }

        public override string ToString()
        {
            return Name + " (" + ContentUrl + ")";
        }
    }
}
