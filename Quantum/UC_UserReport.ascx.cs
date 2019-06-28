using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;
using System.Configuration;

namespace Quantum
{
    public partial class UC_UserReport : System.Web.UI.UserControl
    {
        public int userID = 0;
        public int projectID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack) { hfUserID.Value = userID.ToString(); hfProjectID.Value = projectID.ToString(); }
            //if the user viewing is not the user who owns the project, or the user is not logged in
            if (userID == GoalUser.CurrentUserId(Page) || !GoalUser.UserLoggedIn(Page))
            {
                pnlReport.Visible = false; //don't display option to report
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            userID = int.Parse(hfUserID.Value);
            projectID = int.Parse(hfProjectID.Value);

            //get the project id
            if (userID != 0)
            {
                if (txtMessage.Text.Trim() == "") { litContactMessage.Text = "Please enter a message."; return; }

                //notify the user that they've been sent a message
                GoalUser user = new GoalUser(userID);
                Template template = new Template(Template.Template_New_Report);
                template.InsertValue("message", txtMessage.Text);
                template.InsertValue("userid", userID.ToString());
                template.InsertValue("userName", user.name);
                template.InsertValue("projectid", projectID.ToString());
                string from = ConfigurationSettings.AppSettings["email_adminAddress"].ToString();
                Communication.SendEmail(from, "Co-Founders Network - New Message from " + GoalUser.CurrentUser(Page).name, template.GetTemplateText(), Application);

                litContactMessage.Text = "Thank you for submitting a report. Support will review ASAP.";
                txtMessage.Enabled = false;
                btnReport.Enabled = false;
            }
        }
    }
}