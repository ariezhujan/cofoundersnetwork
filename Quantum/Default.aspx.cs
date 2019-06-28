using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class Default3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GoalUser.Login("eli@fairon.biz", "hhh", Page, true);
            GoalUser.HasCookie(Page);
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            //redirect to sign in
            Page.Response.Redirect("/Signup.aspx", false);


            //signup
            //if email not in use
            //if (txtEmail.Text.Trim()=="")
            //{
            //    litMessage.Text = "Please enter an email address.";
            //}
            //else
            //if (GoalUser.UsernameAvailable(txtEmail.Text))
            //{
            //    //create account
            //    GoalUser user = new GoalUser(txtEmail.Text, "PreLaunch");
            //    user.Create();
            //    user.name = txtEmail.Text;
            //    if (user.name.Contains("@")) { user.name = user.name.Substring(0, user.name.IndexOf("@")); }
            //    user.Update();
            //    litMessage.Text = "Your email '"+ txtEmail.Text +"' has been saved. We will contact you in the near future when the platform is available.";
            //    pnlSignUp.Visible = false;
            //}
            //else
            //{
            //    litMessage.Text = "The email '"+ txtEmail.Text + "' entered already has an account.";
            //}
        }
    }
}