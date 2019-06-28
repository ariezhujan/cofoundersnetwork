using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;
using Brettle.Web.NeatUpload;
using System.Net;

namespace Quantum
{
    public partial class User_Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalUser.CheckUserLoggedIn(Page);
            ucUserProjects.userID = GoalUser.CurrentUserId(Page);

            if (GoalUser.CurrentUserType(Page) == GoalUser.usertype_User_Admin)
            {
                pnlAdmin.Visible = true;
            }
        }
    }
}