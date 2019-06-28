using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace QuantumLibrary.BingSearch
{
    public enum FilterAspect
    {
        /// <summary>
        /// Return images with standard aspect ratio
        /// </summary>
        Square,
        /// <summary>
        /// Return images with wide screen aspect ratio
        /// </summary>
        Wide,
        /// <summary>
        /// Return images with tall aspect ratio
        /// </summary>
        Tall,
        /// <summary>
        /// Do not filter by aspect. Specifying this value is the same as not specifying the aspect parameter.
        /// </summary>
        All
    }

    public enum FilterColor
    {
        /// <summary>
        /// Return color images
        /// </summary>
        ColorOnly,
        /// <summary>
        /// Return black and white images
        /// </summary>
        Monochrome,
        Black,
        Blue,
        Brown,
        Gray,
        Green,
        Orange,
        Pink,
        Purple,
        Red,
        Teal,
        White,
        Yellow
    }

    public enum FilterFreshness
    {
        /// <summary>
        /// Return images discovered within the last 24 hours
        /// </summary>
        Day,
        /// <summary>
        /// Return images discovered within the last 7 days
        /// </summary>
        Week,
        /// <summary>
        /// Return images discovered within the last 30 days
        /// </summary>
        Month
    }

    public enum FilterImageContent
    {
        /// <summary>
        /// Return images that show only a person's face
        /// </summary>
        Face,
        /// <summary>
        /// Return images that show only a person's head and shoulders
        /// </summary>
        Portrait
    }

    public enum FilterImageType
    {
        /// <summary>
        /// Return only animated GIFs
        /// </summary>
        AnimatedGif,
        /// <summary>
        /// Return only clip art images
        /// </summary>
        Clipart,
        /// <summary>
        /// Return only line drawings
        /// </summary>
        Line,
        /// <summary>
        /// Return only photographs (excluding line drawings, animated Gifs, and clip art)
        /// </summary>
        Photo,
        /// <summary>
        /// Return only images that contain items where Bing knows of a merchant that is selling the items.
        /// </summary>
        Shopping
    }

    public enum FilterLicense
    {
        /// <summary>
        /// Return images where the creator has waived their exclusive rights, to the fullest extent allowed by law.
        /// </summary>
        Public,
        /// <summary>
        /// Return images that may be shared with others. Changing or editing the image might not be allowed. Also, modifying, sharing, and using the image for commercial purposes might not be allowed.Typically, this option returns the most images.
        /// </summary>
        Share,
        /// <summary>
        /// Return images that may be shared with others for personal or commercial purposes. Changing or editing the image might not be allowed.
        /// </summary>
        ShareCommercially,
        /// <summary>
        /// Return images that may be modified, shared, and used. Changing or editing the image might not be allowed.Modifying, sharing, and using the image for commercial purposes might not be allowed.
        /// </summary>
        Modify,
        /// <summary>
        /// Return images that may be modified, shared, and used for personal or commercial purposes. Typically, this option returns the fewest images.
        /// </summary>
        ModifyCommercially,
        /// <summary>
        /// Do not filter by license type. Specifying this value is the same as not specifying the license parameter.
        /// </summary>
        All
    }

    public enum FilterSize
    {
        /// <summary>
        /// Return images that are less than 200x200 pixels
        /// </summary>
        Small,
        /// <summary>
        /// Return images that are greater than or equal to 200x200 pixels but less than 500x500 pixels
        /// </summary>
        Medium,
        /// <summary>
        /// Return images that are 500x500 pixels or larger
        /// </summary>
        Large,
        /// <summary>
        /// Return wallpaper images.
        /// </summary>
        Wallpaper,
        /// <summary>
        /// Do not filter by size. Specifying this value is the same as not specifying the size parameter.
        /// </summary>
        All
    }

    

    public static class BingSearcher
    {
        public static ArrayList SearchImages(string searchTerm)
        {
            ArrayList imageURLs = new ArrayList();
            try
            {
                searchTerm = searchTerm.Replace("_", " ");
                int count = 0;
                string imageURL;
                var items = QuantumLibrary.BingSearch.BingSearcher.SearchImages(searchTerm, null, null, null, 0, null, null, null, null, 0);
                foreach (var img in items)
                {
                    imageURLs.Add(RemoveBingFromImageURL(img.ContentUrl));
                    count++;
                    if (count > 20) { break; }
                }
            }
            catch (Exception ex) { }
            return imageURLs;
        }

        /// <summary>
        /// Remove references to Bing in the image URLs.
        /// </summary>
        /// <param name="originalURL"></param>
        /// <returns></returns>
        public static string RemoveBingFromImageURL(string originalURL)
        {
            string returnValue = originalURL;
            if((originalURL.StartsWith("http://www.bing.com") || originalURL.StartsWith("https://www.bing.com")) && originalURL.LastIndexOf("http")!=0) //if starts with bing and there is a substring
            {
                returnValue = returnValue.Substring(returnValue.LastIndexOf("http"), returnValue.Length - (returnValue.LastIndexOf("http")+1)); //remove bing reference
            }
            returnValue = HttpUtility.UrlDecode(returnValue);
            if (returnValue.Contains("&"))
            {
                returnValue = returnValue.Substring(0, returnValue.LastIndexOf("&")); //remove parameters
            }
            return returnValue;
        }

        private static string APIKey = "a86d78a98f594fae9edcfb42e9e7c5ef"; //was 637227c655cb455996675daeb0069ca2

        public static List<BinqImageItem> SearchImages(string q, FilterAspect? aspect, FilterColor? color, FilterFreshness? freshness,
            int height,
            FilterImageContent? imageContent,
            FilterImageType? imageType,
            FilterLicense? license,
            FilterSize? size,
            int width)
        {
            var result = new List<BinqImageItem>();

            var url = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?";
            url += "q=" + q;
            if (aspect.HasValue)
                url += "&aspect=" + aspect.ToString();
            if (color.HasValue)
                url += "&color=" + color.ToString();
            if (freshness.HasValue)
                url += "&freshness=" + freshness.ToString();
            if (height != 0)
                url += "&height=" + height.ToString();
            if (imageContent.HasValue)
                url += "&imageContent=" + imageContent.ToString();
            if (imageType.HasValue)
                url += "&imageType=" + imageType.ToString();
            if (license.HasValue)
                url += "&license=" + license.ToString();
            if (size.HasValue)
                url += "&size=" + size.ToString();
            if (width != 0)
                url += "&width=" + width;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", APIKey);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string s = reader.ReadToEnd();
                var data = JObject.Parse(s);
                var images = data;//data["images"];
                if (images != null && !string.IsNullOrEmpty(images.ToString()))
                {
                    var imgArray = images["value"] as JArray;
                    if (imgArray != null && imgArray.Count > 0)
                    {
                        foreach(var img in imgArray)
                        {
                            var imgItem = new BinqImageItem();
                            imgItem.Name = img.Value<string>("name");
                            imgItem.WebSearchUrl = img.Value<string>("webSearchUrl");
                            imgItem.ThumbnailUrl = img.Value<string>("thumbnailUrl");
                            imgItem.DatePublished = img.Value<DateTime>("datePublished");
                            imgItem.ContentUrl = img.Value<string>("contentUrl");
                            imgItem.HostPageUrl = img.Value<string>("hostPageUrl");
                            imgItem.ContentSize = img.Value<string>("contentSize");
                            imgItem.EncodingFormat = img.Value<string>("encodingFormat");
                            imgItem.HostPageDisplayUrl = img.Value<string>("hostPageDisplayUrl");
                            imgItem.Width = double.Parse(img.Value<string>("width"));
                            imgItem.Height = double.Parse(img.Value<string>("height"));
                            var thumbnail = img["thumbnail"];
                            if (thumbnail != null && !string.IsNullOrEmpty(thumbnail.ToString()))
                            {
                                imgItem.ThumbnailWidth = double.Parse(thumbnail.Value<string>("width"));
                                imgItem.ThumbnailHeight = double.Parse(thumbnail.Value<string>("height"));
                            }

                            result.Add(imgItem);
                        }
                    }
                }
            }

            return result;
        }
    }
}