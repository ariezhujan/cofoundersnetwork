using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;
using Brettle.Web.NeatUpload;
using System.Data;

namespace Quantum
{
    public partial class Project_Edit : System.Web.UI.Page
    {
        int projectID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalUser.CheckUserLoggedIn(Page);

            projectID = Data.validInt(Request["id"]);
            if (!Page.IsPostBack && projectID != 0)
            {
                //get the project id
                Project project = new Project(projectID);
                GoalUser projectUser = new GoalUser(project.UserID_Founder);

                //confirm user permissions to the project or if the user is an admin
                if (project.UserID_Founder != GoalUser.CurrentUserId(Page) && GoalUser.CurrentUserType(Page)!=GoalUser.usertype_User_Admin) { return; }

                //load ddls
                rblIndustry.DataSource = ObjectListValue.GetListValues("Industry", 0, 0, true);
                rblIndustry.DataValueField = "Name";
                rblIndustry.DataTextField = "Name";
                rblIndustry.DataBind();

                rblBusinessStage.DataSource = ObjectListValue.GetListValues("BusinessStage", 0, 0, true); ;
                rblBusinessStage.DataValueField = "Name";
                rblBusinessStage.DataTextField = "Name";
                rblBusinessStage.DataBind();

                //load the project
                txtName.Text = project.Name;
                txtDescription.Text = project.Description;
                txtSummary.Text = project.Summary;
                txtDeliverables.Text = project.Deliverables;
                txtInvestmentAmountRequiredUSD.Text = project.InvestmentAmountRequiredUSD.ToString();
                txtInvestmentAmountRaisedUSD.Text = project.InvestmentAmountRaisedUSD.ToString();
                txtInvestmentAmountMinimumUSD.Text = project.InvestmentAmountMinimumUSD.ToString();
                ddlStatus.SelectedValue = project.Status;
                txtUseOfFunds.Text = project.UseOfFunds;
                txtRisksAndChallenges.Text = project.RisksAndChallenges;
                txtFundingAim.Text = project.FundingAim;
                txtBusinessModel.Text = project.BusinessModel;
                rblIndustry.SelectedValue = project.Industry;
                rblBusinessStage.SelectedValue = project.BusinessStage;
                ddlCountry.Value = project.CountryIncorporated;
                if (project.CountryIncorporated == "") { ddlCountry.Value = projectUser.country; } //use the user's country if there is no country set for the project

                //load misc lists
                ucObjectListValue_PositionsRequired.ObjectID = project.id;
                ucObjectListValue_PositionsRequired.ObjectType = ObjectListValue.ObjectType_projectID;
                ucObjectListValue_PositionsRequired.ValueType = "PositionsRequired";
                ucObjectListValue_PositionsRequired.stringValue1_Name = "Position";
                ucObjectListValue_PositionsRequired.intValue1_Name = "Hours Per Week";
                ucObjectListValue_PositionsRequired.list1RegularExpression = "^(\\d)(\\d)?";
                ucObjectListValue_PositionsRequired.list1RegularExpressionErrorMessage = "Please enter a number from 0 to 99.";
                ucObjectListValue_PositionsRequired.enableEditing = true;

                ucObjectListValue_SkillsRequired.ObjectID = project.id;
                ucObjectListValue_SkillsRequired.ObjectType = ObjectListValue.ObjectType_projectID;
                ucObjectListValue_SkillsRequired.ValueType = "Skills";
                ucObjectListValue_SkillsRequired.list1 = "Skill";
                ucObjectListValue_SkillsRequired.listValueID1_Name = "Skill";
                ucObjectListValue_SkillsRequired.enableEditing = true;

                ucObjectListValue_Milestones.ObjectID = project.id;
                ucObjectListValue_Milestones.ObjectType = ObjectListValue.ObjectType_projectID;
                ucObjectListValue_Milestones.ValueType = "Milestones";
                ucObjectListValue_Milestones.list1 = "Milestone";
                ucObjectListValue_Milestones.listValueID1_Name = "Milestone";
                ucObjectListValue_Milestones.list2 = "MilestoneStatus";
                ucObjectListValue_Milestones.listValueID2_Name = "Status";
                ucObjectListValue_Milestones.list2IncPreviouslyUsed = true;
                ucObjectListValue_Milestones.dateValue1_Name = "Date (dd/mm/yyyy)";
                ucObjectListValue_Milestones.enableEditing = true;

                LoadProjectFiles();
            }
        }

        protected void LoadProjectFiles()
        {
            DataSet ds = File.GetFilesForUser(GoalUser.CurrentUserId(Page), projectID, false);
            dgFiles.DataSource = ds;
            dgFiles.DataBind();

            //hide the table if no files available
            if (ds.Tables[0].Rows.Count == 0)
            {
                dgFiles.Visible = false;
            }
            else
            {
                dgFiles.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Project project = new Project(Data.validInt(Request["id"]));

            //confirm user permissions to the project or if the user is an admin
            if (project.UserID_Founder != GoalUser.CurrentUserId(Page) && GoalUser.CurrentUserType(Page) != GoalUser.usertype_User_Admin) { return; }

            project.Name = txtName.Text;
            project.Description = Data.CleanHTMLPassedIn(txtDescription.Text);
            project.Summary = txtSummary.Text;
            project.Deliverables = txtDeliverables.Text;
            project.InvestmentAmountRequiredUSD = Data.validInt(txtInvestmentAmountRequiredUSD.Text);
            project.InvestmentAmountRaisedUSD = Data.validInt(txtInvestmentAmountRaisedUSD.Text);
            project.InvestmentAmountMinimumUSD = Data.validInt(txtInvestmentAmountMinimumUSD.Text);
            project.Status = ddlStatus.SelectedValue;
            project.UseOfFunds = txtUseOfFunds.Text;
            project.RisksAndChallenges = txtRisksAndChallenges.Text;
            project.FundingAim = txtFundingAim.Text;
            project.BusinessModel = txtBusinessModel.Text;
            project.Industry = rblIndustry.SelectedValue;
            project.BusinessStage = rblBusinessStage.SelectedValue;
            project.CountryIncorporated = ddlCountry.Value;            
            project.Update();
            litUpdateMessage.Text = "Pitch updated.";
        }



        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            int fileID = 0;
            string fileLocation = "";
            //filesize 1,000,000 is 1 MB
            litFileUploadMessage.Text = File.UploadFile(FileUploader, "", HttpContext.Current.Server, Page, 1000000, ref fileID, ref fileLocation, true, "");
            File file = new File(fileID);
            file.projectID = projectID;
            file.Update();

            LoadProjectFiles();

            //scroll to view the image upload section as partial post back is not being used.
            //TODO replace the image upload functionality with a control that can support partial postback.
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "location.hash = \"#anchorUploadFile\";", true);
        }

        protected void btnDeleteFile_Click (object sender, EventArgs e)
        {
            int fileID = 0;
            fileID = Data.validInt(((Button)sender).CommandArgument.ToString());
            //delete the file
            File file = new File(fileID);
            file.Delete(Server);

            LoadProjectFiles();

            litFileUploadMessage.Text = "File deleted.";

            //scroll to view the image upload section as partial post back is not being used.
            //TODO replace the image upload functionality with a control that can support partial postback.
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "location.hash = \"#anchorUploadFile\";", true);
        }

        protected void btnDeleteProject_Click(object sender, EventArgs e)
        {
            //delete the project
            Project project = new Project(projectID);
            project.Delete();

            GoalUser.RedirectHome(Page);
        }
    }
}