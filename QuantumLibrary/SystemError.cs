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
    /// Summary description for SystemError
    /// </summary>
    public class SystemError
    {
        public static void Record(Exception ex)
        {
            //Event.SaveEvent(ex.ToString(), Event.Type_Error);

            string filePath = "";

            try
            {
                filePath = HttpContext.Current.Request.FilePath;
            }
            catch { }

            Event.SaveEvent("MESSAGE: " + ex.Message +
              "\nSOURCE: " + ex.Source +
              "\nTARGETSITE: " + ex.TargetSite +
              "\nSTACKTRACE: " + ex.StackTrace +
              "\nHttpContext.Current.Request.FilePath: " + filePath, Event.Type_Error);
        }
    }

}