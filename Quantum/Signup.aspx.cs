using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;
using System.Configuration;
using System.Globalization;

namespace Quantum
{
    public partial class ds_signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //((MasterPage)(this.Master)).HeaderVisible = false;
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "" || txtPassword.Text.Trim() == "" || !txtEmail.Text.Contains("@")) { litMessage.Text = "Please enter an email address and password."; return; };
            //signup
            //if email not in use
            if (GoalUser.UsernameAvailable(txtEmail.Text))
            {
                //create account
                GoalUser user = new GoalUser(txtEmail.Text, txtPassword.Text);
                user.Create();

                //set/guess the user's name based on their email
                user.name = txtEmail.Text;
                if (user.name.Contains("@")) { user.name = user.name.Substring(0, user.name.IndexOf("@")); }
                user.name = user.name.Replace(".", " ");
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                user.name = textInfo.ToTitleCase(user.name);

                user.Update();

                //email
                if (ConfigurationSettings.AppSettings["siteIsLive"].ToString() == "false")
                {
                    litMessage.Text = "You have successfully signed up and will be notified when the platform is fully operational.";
                    txtEmail.Enabled = false;
                    txtPassword.Enabled = false;
                    btnSignup.Enabled = false;
                }
                else
                {
                    user.SendWelcomeEmail(Server, Application);
                    GoalUser.Login(txtEmail.Text, txtPassword.Text, Page, true);
                }
            }
            else
            {
                litMessage.Text = "This email address is already associated with an account. Please use the forgotten password functionality.";
            }
        }
    }
}