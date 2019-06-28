using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class ds_userpasswordreset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get parameters
            int id = Data.validInt(StringCipher.Decrypt(Request["a"].ToString()));
            string password = StringCipher.Decrypt(Request["b"].ToString());

            //identify if the details provided are accurate and the password hasn't been changed since the password reset request.
            GoalUser user = new GoalUser(id);
            if (user.password != password)
            {
                litMessage.Text = "Reset link has expired. Please attempt the password reset again.";
            }
            else
            {
                //log the user in
                if (user.Authenticate())
                {
                    //load common variables into the session
                    GoalUser.LoadSessionVariables(user, Page, true);

                    litMessage.Text = "You have been logged in. Please change your password via the profile edit page.";
                }
            }
        }
    }
}