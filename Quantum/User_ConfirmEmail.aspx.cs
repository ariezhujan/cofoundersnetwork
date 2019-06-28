using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;
using System.Net;

namespace Quantum
{
    public partial class ds_userconfirmemail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get parameters
            string username = StringCipher.Decrypt(Request.QueryString["a"].ToString());

            GoalUser user = new GoalUser(username);
            if (user.id != 0)
            {
                user.emailAddressConfirmed = true;
                user.Update();
                litMessage.Text = "Your email address has been confirmed. Thank you. Please continue to finalise your <a href='user_edit.aspx'>profile</a>.";
            }
            else
            {
                litMessage.Text = "The details provided are inaccurate. Please contact support.";
            }
        }
    }
}