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

public partial class MasterPage_MegaSWF : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && (Page.Title == "" || Page.Title == "Untitled Page"))
        {
            Page.Title = "Free File Hosting - MegaSWF";
        }
        if (!Page.IsPostBack)
        {
            GoalUser.HasCookie(Page);
        }

        ////if logged in or has cookie
        //if (GoalUser.UserLoggedIn(Page) || GoalUser.HasCookie(Page))
        //{
        //    litUsername.Text = new GoalUser(GoalUser.CurrentUserId(Page)).username;
        //    phNotLoggedIn.Visible = false;
        //    phLoggedIn.Visible = true;
        //}
        //else if(Request["hideLogin"] == null)
        //{
        //    litUsername.Text = "guest";
        //    phNotLoggedIn.Visible = true;
        //    phLoggedIn.Visible = false;
        //}
    }

    
}
