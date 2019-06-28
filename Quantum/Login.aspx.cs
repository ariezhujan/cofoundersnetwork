using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class ds_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //((MasterPage)(this.Master)).HeaderVisible = false;

            if (GoalUser.UserLoggedIn(Page))
            {
                //redirect to starting page
                GoalUser.RedirectHome(Page);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //login
            GoalUser.Login(txtEmail.Text, txtPassword.Text, Page, true);
            litMessage.Text = "Incorrect username or password.";
        }
    }
}