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
using QuantumLibrary;

public partial class FileLinks : System.Web.UI.Page
{
    public int fileID = 0, fileHeight = 0, fileWidth = 0;
    public string upgradeLink = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //get file
        if (Request["fileID"] != null)
        {
            int.TryParse(Request["fileID"].ToString(), out fileID);
        }
        File file = new File();
        file.Load(fileID);
        fileHeight = file.custom_height;
        fileWidth = file.custom_width;
        litFileName.Text = file.fileName;

        litWidth.Text = file.custom_width.ToString();
        litHeight.Text = file.custom_height.ToString();

        //if fileheight or width is incorrect
        if (fileWidth < 0 || fileHeight < 0)
        {
            fileHeight = 300;
            fileWidth = 300;
        }

        //display links
        GoalUser user = GoalUser.Load_FromCache(file.userID, Page);
        if (user.userType == GoalUser.usertype_User_Pro)
        {
            //display pro links
            phLinks_Pro.Visible = true;
            phLinks_NotPro.Visible = false;
        }
        else
        {
            //not pro
            phLinks_Pro.Visible = false;

            if (file.ext.ToLower() == "swf")
            {
                phLinks_NotPro_IsSWF.Visible = true;
            }
            else
            {
                phLinks_NotPro.Visible = true;
            }
        }

        //upgrade to pro
        if (GoalUser.UserLoggedIn(Page))
        {
            //direct to paypal to upgrade
            upgradeLink = PayPal.URL(Page, PayPal.Pro_Month_1);
        }
        else
        {
            //else direct to register
            upgradeLink = "/Register?RegisteringForUpgrade=1&fileID=" + fileID.ToString();
        }

        //fla file
        if (file.ext.ToLower() == "swf")
        {
            //phFLAFile.Visible = true;
            phEmbedCode_SWF.Visible = true;
        }
        else if (file.ext.ToLower() == "fla")
        {
            phDisplayDimentions.Visible = false;
        }
        else if (file.ext.ToLower() == "xap")
        {
            phEmbedCode_XAP.Visible = true;
        }
    }
}
