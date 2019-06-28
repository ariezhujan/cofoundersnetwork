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

public partial class UC_Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if logged in or has cookie
            if (GoalUser.UserLoggedIn(Page) || GoalUser.HasCookie(Page))
            {
                litUsername.Text = new GoalUser(GoalUser.CurrentUserId(Page)).username;
                litUsernameProfile.Text = litUsername.Text;
                phNotLoggedIn.Visible = false;
                phLoggedIn.Visible = true;
            }
            else if (Request["hideLogin"] == null)
            {
                phNotLoggedIn.Visible = true;
                phLoggedIn.Visible = false;
            }

            //check for search para
            if (Request["searchValue"] != null)
            {
                txtSearch.Text = Request["searchValue"];
            }

            //if admin
            if (GoalUser.CurrentUserType(Page) == GoalUser.usertype_User_Admin)
            {
                btnAdminEvents.Visible = true;
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //redirect to search
        if (txtSearch.Text.Trim() != "")
        {
            Response.Redirect("/search/" + txtSearch.Text);
        }
    }

    public void btnLogout_Click(object sender, EventArgs e)
    {
        //logout
        GoalUser.Logout(Page);
    }
}
