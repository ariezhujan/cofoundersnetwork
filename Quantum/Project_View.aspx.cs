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
    public partial class Project_View : System.Web.UI.Page
    {
        public int projectID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //get the project id
                projectID = Data.validInt(Request["id"]);
                if (projectID != 0)
                {
                    Project project = new Project(projectID);

                    //load the project
                    litName.Text = project.Name;
                    litDescription.Text = project.Description;
                    litDeliverables.Text = project.Deliverables;
                    litInvestmentAmountRequiredUSD.Text = "USD$" + String.Format("{0:n0}", project.InvestmentAmountRequiredUSD);
                    litInvestmentAmountRaisedUSD.Text = "USD$" + String.Format("{0:n0}", project.InvestmentAmountRaisedUSD);
                    litInvestmentAmountMinimumUSD.Text = "USD$" + String.Format("{0:n0}", project.InvestmentAmountMinimumUSD);
                    litUseOfFunds.Text = project.UseOfFunds;
                    litRisksAndChallenges.Text = project.RisksAndChallenges;
                    litFundingAim.Text = project.FundingAim;
                    litBusinessModel.Text = project.BusinessModel;
                    litIndustry.Text = project.Industry;
                    litBusinessStage.Text = project.BusinessStage;

                    //if blank, make clear
                    if (litDescription.Text.Trim() == "") { litDescription.Text = "Not Provided"; }
                    if (litDeliverables.Text.Trim() == "") { litDeliverables.Text = "Not Provided"; }
                    if (litUseOfFunds.Text.Trim() == "") { litUseOfFunds.Text = "Not Provided"; }
                    if (litRisksAndChallenges.Text.Trim() == "") { litRisksAndChallenges.Text = "Not Provided"; }
                    if (litFundingAim.Text.Trim() == "") { litFundingAim.Text = "Not Provided"; }
                    if (litBusinessModel.Text.Trim() == "") { litBusinessModel.Text = "Not Provided"; }
                    if (litIndustry.Text.Trim() == "") { litIndustry.Text = "Not Provided"; }

                    //load misc lists
                    ucObjectListValue_PositionsRequired.ObjectID = project.id;
                    ucObjectListValue_PositionsRequired.ObjectType = ObjectListValue.ObjectType_projectID;
                    ucObjectListValue_PositionsRequired.ValueType = "PositionsRequired";
                    ucObjectListValue_PositionsRequired.stringValue1_Name = "Position";
                    ucObjectListValue_PositionsRequired.intValue1_Name = "Hours Per Week";

                    ucObjectListValue_SkillsRequired.ObjectID = project.id;
                    ucObjectListValue_SkillsRequired.ObjectType = ObjectListValue.ObjectType_projectID;
                    ucObjectListValue_SkillsRequired.ValueType = "Skills";
                    ucObjectListValue_SkillsRequired.list1 = "Skill";
                    ucObjectListValue_SkillsRequired.listValueID1_Name = "Skill";

                    ucObjectListValue_Milestones.ObjectID = project.id;
                    ucObjectListValue_Milestones.ObjectType = ObjectListValue.ObjectType_projectID;
                    ucObjectListValue_Milestones.ValueType = "Milestones";
                    ucObjectListValue_Milestones.list1 = "Milestone";
                    ucObjectListValue_Milestones.listValueID1_Name = "Milestone";
                    ucObjectListValue_Milestones.list2 = "MilestoneStatus";
                    ucObjectListValue_Milestones.listValueID2_Name = "Status";
                    ucObjectListValue_Milestones.dateValue1_Name = "Date (dd/mm/yyyy)";

                    //create link to the project founder user
                    GoalUser user = new GoalUser(project.UserID_Founder);
                    hlUser.Text = user.name;
                    hlUser.NavigateUrl = "User.aspx?id=" + user.id;
                    imgUser.ImageUrl = File.uploadedFilesDirectory + "\\" + user.image;

                    //load project files
                    DataSet ds = File.GetFilesForUser(project.UserID_Founder, projectID, false);
                    dgFiles.DataSource = ds;
                    dgFiles.DataBind();
                    if (ds.Tables[0].Rows.Count == 0) { dgFiles.Visible = false; litMessageFiles.Text = "No project files provided."; }

                    //send the project to the contact user control
                    ucUserContact.userID = project.UserID_Founder;

                    //send ids to the report form
                    ucUserReport.userID = user.id;
                    ucUserReport.projectID = project.id;

                    //display the edit button if the user is the creator
                    if (project.UserID_Founder == GoalUser.CurrentUserId(Page) || GoalUser.CurrentUserType(Page)==GoalUser.usertype_User_Admin) { hlEditProject.Visible = true; hlEditProject.HRef = "/Project_Edit.aspx?ID="+projectID.ToString(); }

                    //if not logged in, hide some information
                    if (GoalUser.UserLoggedIn(Page))
                    {
                        pnlLoggedIn.Visible = true;
                    }
                    else
                    {
                        pnlLoggedOut.Visible = true;
                        pnlFiles.Visible = false;
                    }
                }
            }
        }

        
    }
}