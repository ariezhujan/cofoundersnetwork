using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for Default
    /// </summary>
    public class Default
    {
        public static Guid GoalID = new Guid("21B628E5-44A3-4AE8-8B3F-36069CBDED69");


        public Default()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string Root = "/";
        public static string LoginPage = "login.aspx";

        public static string Get(string defaultName)
        {
            return "";
        }

        public static string DisplayTitle(object title, int maxLength)
        {
            //get title from object
            string returnValue = DisplayTrimmed(title, maxLength);

            //set value if title is blank
            if (returnValue == "")
            {
                returnValue = "[no title]";
            }

            return returnValue;
        }

        public static string DisplayTrimmed(object title, int maxLength)
        {
            //get title from object
            string returnValue = "";
            returnValue = title.ToString().Trim();

            //set max length
            if (returnValue.Length > maxLength)
            {
                returnValue = returnValue.Substring(0, maxLength) + "'";
            }

            return returnValue;
        }
    }

}