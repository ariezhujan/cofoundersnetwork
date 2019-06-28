using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class ds_signout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalUser.Logout(Page);
            Page.Response.Redirect("/Default.aspx", false);
        }        
    }
}