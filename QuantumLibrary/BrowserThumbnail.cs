using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Windows.Forms;


namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for BrowserThumbnail
    /// </summary>
    public class BrowserThumbnail
    {
        public string swfURL = "";
        public string swfScreenShotLocationPhysical = "";
        public BrowserThumbnail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void GenerateScreenshotForSWF()
        {
            try
            {
                //get screenshot of swf
                Bitmap thumbnail = GenerateScreenshot(swfURL, 1024, 768);
                //Event.SaveEvent("Screenshot created for url: " + swfURL + " location: " + swfScreenShotLocationPhysical, Event.Type_System_AutoIconCreation, 0);

                //save
                thumbnail.Save(swfScreenShotLocationPhysical, System.Drawing.Imaging.ImageFormat.Jpeg);
                thumbnail.Dispose();
            }
            catch (Exception ex)
            {
                Event.SaveEvent("GenerateScreenshotForSWF() path: " + swfScreenShotLocationPhysical + " error: " + ex.Message.ToString(), Event.Type_System_AutoIconCreation_Failed);
            }
        }

        public Bitmap GenerateScreenshot(string url)
        {
            // This method gets a screenshot of the webpage
            // rendered at its full size (height and width)
            return GenerateScreenshot(url, -1, -1);
        }

        public Bitmap GenerateScreenshot(string url, int width, int height)
        {
            // Load the webpage into a WebBrowser control
            WebBrowser wb = new WebBrowser();
            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(url);

            //Wait
            DateTime timeToStopLoading = DateTime.Now.AddSeconds(15);
            while (wb.ReadyState != WebBrowserReadyState.Complete && DateTime.Now < timeToStopLoading) { Application.DoEvents(); }
            timeToStopLoading = DateTime.Now.AddSeconds(15);
            while (DateTime.Now < timeToStopLoading) { Application.DoEvents(); }

            // Set the size of the WebBrowser control
            wb.Width = width;
            wb.Height = height;

            if (width == -1)
            {
                // Take Screenshot of the web pages full width
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
            }

            if (height == -1)
            {
                // Take Screenshot of the web pages full height
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }

            // Get a Bitmap representation of the webpage as it's rendered in the WebBrowser control
            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            
            //Wait
            timeToStopLoading = DateTime.Now.AddSeconds(15);
            while (wb.ReadyState != WebBrowserReadyState.Complete && DateTime.Now < timeToStopLoading) { Application.DoEvents(); }
            timeToStopLoading = DateTime.Now.AddSeconds(15);
            while (DateTime.Now < timeToStopLoading) { Application.DoEvents(); }

            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();

            return bitmap;
        }
    }
}