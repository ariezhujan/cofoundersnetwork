using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class Admin_Project_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dgProjects.DataSource = Project.GetProjects();
            dgProjects.DataBind();
        }
    }
}