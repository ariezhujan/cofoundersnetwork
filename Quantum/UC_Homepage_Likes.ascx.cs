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

public partial class UC_Homepage_Likes : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = File.GetUserLike(GoalUser.CurrentUserId(Page));
        if (ds.Tables[0].Rows.Count > 0)
        {
            repUserLikes.DataSource = ds;
            repUserLikes.DataBind();
        }
        else
        {
            phLikes.Visible = false;
        }
    }
}
