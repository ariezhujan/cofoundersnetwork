using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class ds_forgottenpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "") { litMessage.Text = "Please enter an email address."; return; };
            //signup
            //if email is notfound
            if (GoalUser.UsernameAvailable(txtEmail.Text))
            {
                litMessage.Text = "The email address entered cannot be found. Please try again or contact support.";
            }
            else
            {
                //find account by email address
                GoalUser user = new GoalUser(txtEmail.Text);

                //send email to the user with a link to reset the password
                //get template
                Template template = new Template(Template.Template_User_Password_Reset);
                template.InsertValue("name", user.name);
                template.InsertValue("a", Server.UrlEncode(StringCipher.Encrypt(user.id.ToString())));
                template.InsertValue("b", Server.UrlEncode(StringCipher.Encrypt(user.password.ToString())));

                //send email
                Communication.SendEmail(user.username, "Co-Founders Network Password Reset", template.GetTemplateText(), Application);

                btnResetPassword.Enabled = false;
                txtEmail.Enabled = false;
                litMessage.Text = "Please check your email to reset the password.";
            }
        }
    }
}