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

public partial class ServeSilverlight : System.Web.UI.Page
{
    public string fileLocation = "", fileHeight = "0", fileWidth = "0", fileID;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["fileID"] != null)
            {
                fileID = Request["fileID"].ToString();
            }
            if (Request["fileHeight"] != null)
            {
                fileHeight = Request["fileHeight"].ToString();
            }
            if (Request["fileWidth"] != null)
            {
                fileWidth = Request["fileWidth"].ToString();
            }
        }
        catch
        { }
    }
}
