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

public partial class ForgotPassword : System.Web.UI.Page
{
    public void btnSubmit_Click(object sender, EventArgs e)
    {
        //get email address for username/email passed
        string password = "", email = "";
        if (GoalUser.GetPassword(txtAccount.Text, ref password, ref email))
        {
            //email password to email address
            Communication.SendEmail(email, "MegaSWF Passord Retrieval", "Your MegaSWF password is: " + password);

            litMessage.Text = "Your password has been emailed to: " + email;
        }
        else
        {
            litMessage.Text = "Your account cannot be found. Contact the <a href='/help'>help desk</a>.";
        }
    }
}
