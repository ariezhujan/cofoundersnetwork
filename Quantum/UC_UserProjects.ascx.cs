using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;
using System.Data;

namespace Quantum
{
    public partial class UC_UserProjects : System.Web.UI.UserControl
    {
        public int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProjects();                
            }
        }

        protected void LoadProjects()
        {
            //load projects
            DataSet ds = Project.GetProjects(userID);
            dgProjects.DataSource = ds;
            dgProjects.DataBind();

            if (ds.Tables[0].Rows.Count == 0)
            {
                dgProjects.Visible = false;
                pnlNoProjects.Visible = true;
            }
        }

        protected void btn_CreateNewProject_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text.Trim() == "")
            {
                litNewProjectMessage.Text = "Please enter a project name.";
                return;
            }

            //create project object
            Project project = new Project(txtProjectName.Text);
            project.Create();

            ProjectUser projectUser = new ProjectUser(1, project.id, GoalUser.CurrentUserId(Page));
            projectUser.Create();

            //redirect to edit the project
            project.RedirectEdit(Page);
        }
    }
}