using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using megaswfLibrary;

public partial class ThumbVideo : System.Web.UI.Page
{
    public int fileID = 0;
    public string thumbVideo = "/file/3935.flv", videoFrame;
    public string width = "90", height = "70";
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the file based on file id passed
        if (Request["fileID"] != null)
        {
            int.TryParse(Request["fileID"].ToString(), out fileID);
        }

        //get width/hight to use
        if (Request["width"] != null)
        {
            width = Request["width"].ToString();
        }
        if (Request["height"] != null)
        {
            height = Request["height"].ToString();
        }

        File file = File.Load_FromCache(fileID, Page);

        //if the file exists
        if (file.location_thumb_video_9070_exists)
        {
            thumbVideo = file.location_thumb_video_9070;
            thumbVideo = thumbVideo.Replace("\\", "/");
            videoFrame = "http://files.megaswf.com/" + file.image_videoFrame;
        }
        else
        {
            //redirect to the thumb
            Response.Redirect(File.DisplayImagePath(file.image));
        }
    }
}
