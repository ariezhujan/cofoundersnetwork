using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing.Imaging;
using System.Configuration;
using System.Text.RegularExpressions;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for Data
    /// </summary>
    public class Data
    {

        public Data()
        {
        }


        #region "Valid Data"
        /// <summary>
        /// Passed a value and returns a valid date
        /// </summary>
        /// <param name="passValue"></param>
        /// <returns></returns>
        public static DateTime validDateTime(string passValue)
        {
            DateTime returnValue;
            DateTime.TryParse(passValue, out returnValue);

            if (returnValue.ToString("yyyyMMdd") == "00010101")
            {
                return defaultDateTime();
            }
            return returnValue;
        }

        public static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }

        /// <summary>
        /// Passed a value and returns a valid guid
        /// </summary>
        /// <param name="passValue"></param>
        /// <returns></returns>
        public static Guid validGuid(string passValue)
        {
            Guid returnValue = Guid.Empty;
            try
            {
                returnValue = new Guid(passValue);
            }
            catch { }
            return returnValue;
        }

        /// <summary>
        /// Passed a value and returns a valid int
        /// </summary>
        /// <param name="passValue"></param>
        /// <returns></returns>
        public static int validInt(string passValue)
        {
            int returnValue = 0;
            int.TryParse(passValue, out returnValue);
            return returnValue;
        }

        /// <summary>
        /// Passed a value and returns a valid float
        /// </summary>
        /// <param name="passValue"></param>
        /// <returns></returns>
        public static float validFloat(string passValue)
        {
            float returnValue = 0;
            float.TryParse(passValue, out returnValue);
            return returnValue;
        }

        /// <summary>
        /// Passed a value and returns a valid decimal
        /// </summary>
        /// <param name="passValue"></param>
        /// <returns></returns>
        public static decimal validDecimal(string passValue)
        {
            decimal returnValue = 0;
            decimal.TryParse(passValue, out returnValue);
            return returnValue;
        }

        public static ArrayList GetMatchesInPage(string InputText, string regEx)
        {
            //do regex
            Regex exp = new Regex(regEx, RegexOptions.IgnoreCase);
            //string InputText = "/quotes/authors/w/william_osler.html\"//quotes/authors/w/willidfghdam_osler.html\"";
            MatchCollection MatchList = exp.Matches(InputText);

            ArrayList al = new ArrayList();

            //add values that match the regex to the array list
            int i = MatchList.Count;
            while (i > 0)
            {
                Match match = MatchList[i - 1];
                //Message(match.Value);

                al.Add(match);


                i--;
            }

            return al;
        }

        /// <summary>
        /// Passed an int and returns a valid bool
        /// </summary>
        /// <param name="passValue"></param>
        /// <returns></returns>
        public static bool validBool(int passValue)
        {
            bool returnValue = false;
            if (passValue == 1)
            {
                returnValue = true;
            }
            return returnValue;
        }
        /// <summary>
        /// Passed a string and returns a valid bool
        /// </summary>
        /// <param name="passValue"></param>
        /// <returns></returns>
        public static bool validBool(string passValue)
        {
            bool returnValue = false;
            if (!bool.TryParse(passValue, out returnValue))
            {
                int passValue_int = 0;
                if (int.TryParse(passValue, out passValue_int))
                {
                    //if int (1,0) then run validBool(int passValue)
                    returnValue = validBool(passValue_int);
                }
            }

            return returnValue;
        }

        public static string CreateRandomString(int stringLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyz0123456789";
            char[] chars = new char[stringLength];
            Random rd = new Random();

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
        #endregion


        #region "Get from session / querystring"
        //passed the page, a query name and a guid to output to
        //returns the success if the querystring contains a valid id
        public static bool getFromQuerystring(Page page, string queryName, out Guid id)
        {
            Guid Id = Guid.Empty;
            try
            {
                Id = new Guid(page.Request[queryName].ToString());
                id = Id;
                return true;
            }
            catch
            {
                id = Guid.Empty;
                return false;
            }
        }
        public static bool getFromQuerystring(Page page, string queryName, out string id)
        {
            try
            {
                id = page.Request[queryName].ToString();
                return true;
            }
            catch
            {
                id = "";
                return false;
            }
        }

        /// <summary>
        /// Returns a session variable if its present
        /// </summary>
        /// <param name="page"></param>
        /// <param name="sessionVariableName"></param>
        /// <returns></returns>
        public static string getFromSession(Page page, string sessionVariableName)
        {
            string returnValue = "";
            try
            {
                returnValue = page.Session[sessionVariableName].ToString();
            }
            catch { }
            return returnValue;
        }
        #endregion


        #region "Display data formatting"

        public static string DefaultValueOnEmptyString(string inputString, string defaultValue)
        {
            if (inputString.Trim() == "") { return defaultValue; } else { return inputString; }
        }

        /// <summary>
        /// Returns string formatted to a max length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string maxStringDisplay(object value, int length)
        {
            string valueString = value.ToString();
            string returnValue; 
            if (valueString.Length > length)
            {
                returnValue =  valueString.Substring(0, length) + "...";
            }
            else
            {
                returnValue =  valueString;
            }

            returnValue = Remove(returnValue, "<", ">", "<a href=\"");
            return returnValue;
        }

        /// <summary>
        /// Function is passed a string and returns the string with the newline chars replaced with <br /> for html
        /// Changed 29/9/07 to do all formatting via the textile dll in the bin folder
        /// </summary>
        /// <returns></returns>
        public static string format(object value)
        {
            string returnValue = value.ToString();
            returnValue = nlToBr(returnValue);
            returnValue = returnValue.Replace("!","{exclamation}");
            returnValue = Textile.TextileFormatter.FormatString(returnValue);
            returnValue = returnValue.Replace("{exclamation}", "!");
            //Textile.TextileFormatter t = new TextileFormatter();
            //t.NoImage = true;
            returnValue = htmlLinks(returnValue); //make all urls not in a hyperlink into links
            return returnValue;
        }
        public static string nlToBr(object value)
        {
            string returnValue = value.ToString();
            //returnValue = returnValue.Replace(System.Environment.NewLine, "<br>");
            returnValue = returnValue.Replace("\n", "<br />");
            return returnValue;
        }


        public static string breakLongWords(object value)
        {
            string passValue = value.ToString();
            string returnValue = "";
            int valueLength = passValue.Length;
            int charCount = 0;
            int wordLengthCount = 0;
            string character = "";

            while (charCount < valueLength)
            {
                //get char
                character = passValue.Substring(charCount, 1);

                //count word length
                if (character == " ")
                {
                    wordLengthCount = 0;
                }
                else
                {
                    wordLengthCount++;
                }

                //if word length is large
                if (wordLengthCount > 30)
                {
                    returnValue = returnValue + " ";
                    wordLengthCount = 0; //reset word length
                }

                //add character to return value
                returnValue = returnValue + character;

                charCount++;
            }

            return returnValue;            
        }

        /// <summary>
        /// Turns urls into html links
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string htmlLinks(object value)
        {
            string returnValue = value.ToString();
            //returnValue = Regex.Replace(returnValue, "!(.+)!", "<img src=\"$1\" />"); //images
            //returnValue = Regex.Replace(returnValue, "\"(.+)\":(.+)(( |\n|\t)|$)", "<a href=\"$2\">$1</a>$3"); //textile link
            //returnValue = Regex.Replace(returnValue, "(?<!/)www\\.([^\\s]+)", "<a href=\"http://www.$1\">www.$1</a>"); //www.google.com.au
            //returnValue = Regex.Replace(returnValue, "(?<!\")http:([^\\s]+)", "<a href=\"http:$1\">http:$1</a>"); //http://www.google.com.au
            return returnValue;
        }
        #endregion


        #region "Dates"
        public static DateTime defaultDateTime()
        {
            return new DateTime(01, 01, 01);
        }
        public static bool dateIsNull(DateTime date)
        {
            if (date == null)
            {
                return true;
            }
            if (date == defaultDateTime())
            {
                return true;
            }
            return false;
        }
        public static string formatDateTime(object datetime)
        {
            string returnString = "";
            DateTime dt = defaultDateTime();
            DateTime.TryParse(datetime.ToString(),out dt);
            if (dt != defaultDateTime()) { returnString = dt.ToString("dd/MM/yyyy"); }

            return returnString;
        }

        /// <summary>
        /// Returns what period the date was within. (less than 2 days, less than 7, less than 14, other...)
        /// </summary>
        /// <param name="dateCreated"></param>
        /// <returns></returns>
        public static string datePeriod(object dateCreated)
        {
            string returnValue = "";

            DateTime date;
            if (DateTime.TryParse(dateCreated.ToString(), out date))
            {
                TimeSpan ts = DateTime.Now.Subtract(date);
                int days = ts.Days;
                if (days <= 2)
                {
                    returnValue = "1";
                }
                else if (days <= 7)
                {
                    returnValue = "2";
                }
                else if (days <= 14)
                {
                    returnValue = "3";
                }
                else
                {
                    returnValue = "4";
                }
            }
            else
            {
                returnValue = "4";
            }

            return returnValue;
        }
        #endregion

        #region "Files"
        public static string ReadFromFile_TextReader(string fileLocation)
        {
            try
            {
                // create reader & open file
                TextReader tr = new StreamReader(fileLocation);

                // read a line of text
                string returnValue = tr.ReadToEnd();

                // close the stream
                tr.Close();

                return returnValue;
            }
            catch (Exception ex)
            {
                Event.SaveEvent("Data.ReadFromFile_TextReader - error: " + ex.Message.ToString() + " fileLocation: " + fileLocation, Event.Type_Error);
                return "";
            }
        }
        public static string ReadFromFile(string fileLocation)
        {
            return System.IO.File.ReadAllText(fileLocation);
        }

        /// <summary>
        /// Removes text outside of the first index of parameter one and first index of parameters two
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OutsideOfStrings(string one, string two, string value)
        {
            //get index of first string
            int one_index = value.IndexOf(one);
            int two_index = value.IndexOf(two);

            //if both the strings are found
            if (one_index!=-1 && two_index!=-1)
            {
                //get first part
                string first_part = value.Substring(0, one_index);
                //get second part
                string second_part = value.Substring(two_index+two.Length, value.Length-(two_index + two.Length));
                return first_part + second_part;
            }
            return value;
        }

        /// <summary>
        /// Removes text outside of the first index of parameter one and last index of parameters two
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OutsideOfStrings_FirstandLastIndex(string one, string two, string value)
        {
            //get index of first string
            int one_index = value.IndexOf(one);
            int two_index = value.LastIndexOf(two);

            //if both the strings are found
            if (one_index != -1 && two_index != -1)
            {
                //get first part
                string first_part = value.Substring(0, one_index);
                //get second part
                string second_part = value.Substring(two_index + two.Length, value.Length - (two_index + two.Length));
                return first_part + second_part;
            }
            return value;
        }

        /// <summary>
        /// Returns text between the first index of parameter one and the first index of parameters two
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string BetweenStrings(string one, string two, string value)
        {
            try
            {
                if (value.Trim() == "")
                {
                    return "";
                }
                else
                {
                    //look for bracket strings
                    int locationOfOne = value.LastIndexOf(one);
                    if (locationOfOne != -1)
                    {
                        //if found, return content between brackets
                        int start = locationOfOne + one.Length;
                        int last = value.IndexOf(two, start);
                        int len = last - start;
                        return value.Substring(start, len);
                    }
                    else
                    {
                        //else return ""
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Returns text between the first index of parameter one and last index of parameters two
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string BetweenStrings_FirstandLastIndex(string one, string two, string value)
        {
            try
            {
                if (value.Trim() == "")
                {
                    return "";
                }
                else
                {
                    //look for bracket strings
                    int locationOfOne = value.IndexOf(one);
                    if (locationOfOne != -1)
                    {
                        //if found, return content between brackets
                        int start = locationOfOne + one.Length;
                        int last = value.LastIndexOf(two);
                        int len = last - start;
                        return value.Substring(start, len);
                    }
                    else
                    {
                        //else return ""
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion 

        public static void DDL_SetSelectedValue(string value, DropDownList ddl)
        {
            //for each ddl item
            int count = ddl.Items.Count-1;
            while (count >= 0)
            {
                //if item equals passed value, set selected
                if (ddl.Items[count].Value == value)
                {
                    ddl.Items[count].Selected = true;
                    return;
                }
                count = count - 1;
            }
        }

        /// <summary>
        /// Used to remove attacking code from HTML passed into the application from users. This needs to be improved as it is very basic at present. TODO
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CleanHTMLPassedIn(string value)
        {
            value = value.Replace("<script", "");
            //value = value.Replace("<iframe", ""); //EF - Allowing for youtube embedding
            value = value.Replace("<form", "");
            value = value.Replace("<object", "");
            value = value.Replace("<embed", "");
            value = value.Replace("<link", "");
            value = value.Replace("<head", "");
            value = value.Replace("<meta", "");
            return value;
        }

        /// <summary>
        /// Remove all HTML from a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripHTML(string input)
        {
            string a = Regex.Replace(input, "<.*?>", String.Empty);
            a = Regex.Replace(a, "<.*?>", String.Empty);
            a = Regex.Replace(a, @"<[^>]+>", "").Trim();
            return a;
        }

        static public string Remove(string value, string r1)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            return value;
        }
        static public string Remove(string value, string r1, string r2)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            if (r2 != "") { value = value.Replace(r2, ""); }
            return value;
        }
        static public string Remove(string value, string r1, string r2, string r3)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            if (r2 != "") { value = value.Replace(r2, ""); }
            if (r3 != "") { value = value.Replace(r3, ""); }
            return value;
        }
        static public string Remove(string value, string r1, string r2, string r3, string r4)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            if (r2 != "") { value = value.Replace(r2, ""); }
            if (r3 != "") { value = value.Replace(r3, ""); }
            if (r4 != "") { value = value.Replace(r4, ""); }
            return value;
        }
        static public string Remove(string value, string r1, string r2, string r3, string r4, string r5)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            if (r2 != "") { value = value.Replace(r2, ""); }
            if (r3 != "") { value = value.Replace(r3, ""); }
            if (r4 != "") { value = value.Replace(r4, ""); }
            if (r5 != "") { value = value.Replace(r5, ""); }
            return value;
        }
        static public string Remove(string value, string r1, string r2, string r3, string r4, string r5, string r6)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            if (r2 != "") { value = value.Replace(r2, ""); }
            if (r3 != "") { value = value.Replace(r3, ""); }
            if (r4 != "") { value = value.Replace(r4, ""); }
            if (r5 != "") { value = value.Replace(r5, ""); }
            if (r6 != "") { value = value.Replace(r6, ""); }
            return value;
        }
        static public string Remove(string value, string r1, string r2, string r3, string r4, string r5, string r6, string r7)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            if (r2 != "") { value = value.Replace(r2, ""); }
            if (r3 != "") { value = value.Replace(r3, ""); }
            if (r4 != "") { value = value.Replace(r4, ""); }
            if (r5 != "") { value = value.Replace(r5, ""); }
            if (r6 != "") { value = value.Replace(r6, ""); }
            if (r7 != "") { value = value.Replace(r7, ""); }
            return value;
        }
        static public string Remove(string value, string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8)
        {
            if (r1 != "") { value = value.Replace(r1, ""); }
            if (r2 != "") { value = value.Replace(r2, ""); }
            if (r3 != "") { value = value.Replace(r3, ""); }
            if (r4 != "") { value = value.Replace(r4, ""); }
            if (r5 != "") { value = value.Replace(r5, ""); }
            if (r6 != "") { value = value.Replace(r6, ""); }
            if (r7 != "") { value = value.Replace(r7, ""); }
            if (r8 != "") { value = value.Replace(r8, ""); }
            return value;
        }

        static public string RemoveDuplicateWords(string v)
        {
            // 1
            // Keep track of words found in this Dictionary.
            Dictionary<string, bool> d = new Dictionary<string, bool>();

            // 2
            // Build up string into this StringBuilder.
            StringBuilder b = new StringBuilder();

            // 3
            // Split the input and handle spaces and punctuation.
            string[] a = v.Split(new char[] { ' ', ',', ';', '.' },
                StringSplitOptions.RemoveEmptyEntries);

            // 4
            // Loop over each word
            foreach (string current in a)
            {
                // 5
                // Lowercase each word
                string lower = current.ToLower();

                // 6
                // If we haven't already encountered the word,
                // append it to the result.
                if (!d.ContainsKey(lower))
                {
                    b.Append(current).Append(' ');
                    d.Add(lower, true);
                }
            }
            // 7
            // Return the duplicate words removed
            return b.ToString().Trim();
        }

        //static public bool DownloadStringSafe(string url, ref string returnString, ref string errorMessage)
        //{
        //    try
        //    {
        //        returnString = DownloadString(url);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = ex.Message;
        //    }
        //    returnString = "";
        //    return false;
        //}
        static public string DownloadString(string url)
        {
            try
            {
                //OPTION 1
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls12
                | SecurityProtocolType.Ssl3;
                WebClient wc = new WebClient();
                Uri myUri = new Uri(url, UriKind.Absolute);
                wc.Headers.Add("Accept", "text/plain");
                wc.Headers.Add("Accept-Language", "en-US");
                //wc.Headers.Add("user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36");
                wc.Headers.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.0; Trident/5.0)");
                wc.Encoding = Encoding.UTF8;
                string returnValue = wc.DownloadString(myUri);
                return returnValue;

                //OPTION 2
                //using (HttpClient client = new HttpClient())
                //using (HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult())
                //    return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote server returned an error: (404) Not Found.")
                {
                    return "";
                }
                else
                {
                    Event.SaveEvent("Error in DownloadString: " + ex.Message + " URL: " + url + " Inner message: " + ex.StackTrace.ToString(), Event.Type_Error);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Downloads an image and returns the location the file was saved to.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static public string DownloadImage(Image image, string location)
        {
            string downloadLocation = "";
            try
            { 
                downloadLocation = location + CreateRandomString(14) + "." + image.ImageURL_Original_Extension;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Tls12
                | SecurityProtocolType.Ssl3;

                WebClient wc = new WebClient();
                Uri myUri = new Uri(image.ImageURL_Original, UriKind.Absolute);
                wc.Headers.Add("user-agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36");
                wc.DownloadFile(myUri, downloadLocation);

                return downloadLocation;
            }
            catch (Exception ex)
            {
                Event.SaveEvent("Error in DownloadImage: " + ex.Message + " URL: " + image.ImageURL_Original + " Inner message: " + ex.StackTrace.ToString(), Event.Type_Error);
                if (ex.Message == "The remote server returned an error: (503) Server Unavailable." || ex.Message == "The remote server returned an error: (403) Forbidden." || ex.Message == "The operation has timed out." || ex.Message == "Unable to connect to the remote server" || ex.Message == "The remote server returned an error: (504) Gateway Timeout." || ex.Message == "The request was aborted: The connection was closed unexpectedly." || ex.Message == "The remote server returned an error: (522) Origin Connection Time-out." || ex.Message == "Invalid URI: The format of the URI could not be determined." || ex.Message == "The remote server returned an error: (404) Not Found." || ex.Message.StartsWith("The remote name could not be resolved:") || ex.Message.StartsWith("The underlying connection was closed:"))
                {
                    return "";
                }
                throw ex;
            }            
        }
    }
}