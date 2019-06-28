using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class Blog : System.Web.UI.Blog
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (GoalUser.UserLoggedIn(Page))
                {
                    litUsername.Text = GoalUser.CurrentUser(Page).name;
                    phSignedIn.Visible = true;
                    phSignedOut.Visible = false;
                }
                else
                {
                    phSignedIn.Visible = false;
                    phSignedOut.Visible = true;
                }

                //litIPAddress.Text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            GoalUser.Logout(Page);
        }
    }
}