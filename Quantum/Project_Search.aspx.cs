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
    public partial class Project_Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //create options for the age ddls
                LoadDDLAge(ddlAgeFrom, 0);
                LoadDDLAge(ddlAgeTo, 99);

                //create options for the investment amount ddls
                LoadDDInvestmentAmount(ddlInvestmentAmountRequiredUSDFrom, 0);
                LoadDDInvestmentAmount(ddlInvestmentAmountRequiredUSDTo, 10000000);

                //TODO CACHING
                rblIndustry.DataSource = ObjectListValue.GetListValues("Industry", 0, 0, true);
                rblIndustry.DataValueField = "Name";
                rblIndustry.DataTextField = "Name";
                rblIndustry.DataBind();

                rblBusinessStage.DataSource = ObjectListValue.GetListValues("BusinessStage", 0, 0, true); ;
                rblBusinessStage.DataValueField = "Name";
                rblBusinessStage.DataTextField = "Name";
                rblBusinessStage.DataBind();

                Search();
            }            
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            Search();
        }

        protected void Search()
        {
            List<string> businessStages = new List<string>();
            foreach (ListItem listItem in rblBusinessStage.Items)
            {
                if (listItem.Selected)
                {
                    businessStages.Add(listItem.Text);
                }
            }

            List<string> industries = new List<string>();
            foreach (ListItem listItem in rblIndustry.Items)
            {
                if (listItem.Selected)
                {
                    industries.Add(listItem.Text);
                }
            }

            List<int> startUpExperience = new List<int>();
            foreach (ListItem listItem in rblStartUpExperience.Items)
            {
                if (listItem.Selected)
                {
                    startUpExperience.Add(Data.validInt(listItem.Value));
                }
            }

            DataSet ds = Project.GetProjects(businessStages, industries, startUpExperience, Data.validInt(ddlAgeFrom.SelectedValue), Data.validInt(ddlAgeTo.SelectedValue), ddlCountry.Value, Data.validInt(ddlInvestmentAmountRequiredUSDFrom.SelectedValue), Data.validInt(ddlInvestmentAmountRequiredUSDTo.SelectedValue));

            //if the admin view
            if (GoalUser.CurrentUserType(Page) == GoalUser.usertype_User_Admin && Request["admin"] != null)
            {
                dgProjectsAdmin.DataSource = ds;
                dgProjectsAdmin.DataBind();
                dgProjectsAdmin.Visible = true;
            }
            else
            {
                dgProjects.DataSource = ds;
                dgProjects.DataBind();
                dgProjects.Visible = true;
            }

            if (ds.Tables[0].Rows.Count == 0) { litMessage.Text = "No projects found. Please expand the search criteria."; } else { litMessage.Text = ""; }
        }

        /// <summary>
        /// Create the list of ages to include in the search drop down lists
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="defaultAmount"></param>
        protected void LoadDDLAge(DropDownList ddl, int defaultAmount)
        {
            int i = 0;
            while (i<100)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                i++;
            }
            ddl.SelectedValue = defaultAmount.ToString();
        }

        /// <summary>
        /// Create the list of investment amounts to include in the search drop down lists
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="defaultAmount"></param>
        protected void LoadDDInvestmentAmount(DropDownList ddl, int defaultAmount)
        {
            ddl.Items.Add(new ListItem("0", "0"));
            ddl.Items.Add(new ListItem("100", "100"));
            ddl.Items.Add(new ListItem("500", "500"));
            ddl.Items.Add(new ListItem("1,000", "1000"));
            ddl.Items.Add(new ListItem("5,000", "5000"));
            ddl.Items.Add(new ListItem("10,000", "10000"));
            ddl.Items.Add(new ListItem("50,000", "50000"));
            ddl.Items.Add(new ListItem("100,000", "100000"));
            ddl.Items.Add(new ListItem("500,000", "500000"));
            ddl.Items.Add(new ListItem("1,000,000", "10000000"));
            ddl.Items.Add(new ListItem("5,000,000", "50000000"));
            ddl.Items.Add(new ListItem("10,000,000", "10000000"));
            ddl.SelectedValue = defaultAmount.ToString();
        }
    }
}