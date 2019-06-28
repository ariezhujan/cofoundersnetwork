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

public partial class FileServe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //get fileid
            if (Request["fileID"] == null)
            {
                return;
            }

            //if file id passed is not an integer
            int fileID = 0;
            if (!int.TryParse(Request["fileID"].ToString(), out fileID))
            {
                return;
            }

            //use caching for file and user objects
            File file = File.Load_FromCache(fileID, Page);
            GoalUser user = GoalUser.Load_FromCache(file.userID, Page);

            //check delete
            if (!Data.dateIsNull(file.deletedDate))
            {
                return;
            }

            //add a view to num_views
            file.AddView();

            //check that file is hosted locally (externally hosted files start with http. eg mochi games)
            if (file.location.StartsWith("http"))
            {
                //redirect
                Response.Redirect(file.location, false);
                return;
            }

            //check the refferer
            string referrer = "";
            string referrerDomain = "";
            if (Request.UrlReferrer != null)
            {
                referrer = Request.UrlReferrer.ToString();

                //get domain of referrer
                referrerDomain = referrer.Replace("http://www.", "").Replace("http://", ""); ;

                //if contains a '/', get just the domain
                if (referrerDomain.Contains("/"))
                {
                    referrerDomain = referrerDomain.Substring(0, referrerDomain.IndexOf("/"));
                }
            }

            //if the refferer is not from megaswf, redirect to megaswf unless the file owner is pro
            if (!referrerDomain.Contains("megaswf.com") && !referrerDomain.StartsWith("localhost") && referrerDomain.Trim()!="")
            {
                if (file.fileType == File.fileType_video)
                {
                    Event.SaveEvent("video file "+ file.id.ToString()+" referrer: " + referrer, Event.Type_System);
                }                

                //if not pro, redirect to serve page
                if (user.userType != GoalUser.usertype_User_Pro)
                {
                    //stop hotlinking -20120923
                    Response.Redirect("/serve/" + file.id.ToString());
                    return;

                    //redirect to serve page is not mp3
                    //if (file.ext != "mp3")

                    //redirect to serve page only if its a swf
                    if (file.ext == "swf")
                    {
                        Response.Redirect("/serve/" + file.id.ToString());
                        return;
                    }
                }
                else
                {
                    //if pro
                    //if the file is 'private + no hotlink' 
                    if (file.privacy == File.privacy_private_hotlinkingDisabled)
                    {
                        //and the domain is not in the whitelist, throw error
                        if (!user.embedWhiteList.Contains(referrerDomain))
                        {
                            Event.SaveEvent("The refferer (" + referrerDomain + ") is not in the whitelist.", Event.Type_Error, file.id);

                            //if domain not in whitelist, display error
                            Response.Write("The refferer (" + referrerDomain + ") is not in the whitelist. Edit your whitelist within your user profile or change the privacy level of the file from 'Private + No Hotlink'.<br /><br /><br /><b>Whitelist:</b><br /><br />" + user.embedWhiteList.Replace(Environment.NewLine, "<br />"));
                            return;
                        }
                    }
                }
            }

            //return file
            if (!File.DownloadFile(file, Response, Server, true))
            {
                //Event.SaveEvent("FileServe.aspx File Not Found: " + fileID.ToString() + "referrer: " + referrer + " Request.Url:" + Request.Url.ToString(), Event.Type_Error);
                Response.Write("File not found.");
            }
        }
        catch (Exception ex)
        {
            //Event.SaveEvent("Fileserve.aspx - error: " + ex.Message.ToString(), Event.Type_Error);
        }
    }
}
