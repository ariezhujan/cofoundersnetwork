using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;
using System.Data;
using System.Collections.Generic;

namespace Quantum
{
    public partial class User_Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //create options for the age ddls
                LoadDDLAge(ddlAgeFrom, 0);
                LoadDDLAge(ddlAgeTo, 99);

                //TODO CACHING
                //load drop down lists
                cblSkills.DataSource = ObjectListValue.GetListValues("Skill", 0, 0, true);
                cblSkills.DataValueField = "ID";
                cblSkills.DataTextField = "Name";
                cblSkills.DataBind();

                rblIndustry.DataSource = ObjectListValue.GetListValues("Industry", 0, 0, true);
                rblIndustry.DataValueField = "Name";
                rblIndustry.DataTextField = "Name";
                rblIndustry.DataBind();

                rblBusinessStage.DataSource = ObjectListValue.GetListValues("BusinessStage", 0, 0, true);
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
            //get drop down list values
            string country = ddlCountry.Value;
            if (country.Trim() == "") { country = "Any"; }

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

            List<int> skills = new List<int>();
            foreach (ListItem listItem in cblSkills.Items)
            {
                if (listItem.Selected)
                {
                    skills.Add(Data.validInt(listItem.Value));
                }
            }

            DataSet ds = GoalUser.GetUsers(businessStages, industries, startUpExperience, Data.validInt(ddlAgeFrom.SelectedValue), Data.validInt(ddlAgeTo.SelectedValue), country, skills);

            //if the admin view
            if (GoalUser.CurrentUserType(Page) == GoalUser.usertype_User_Admin && Request["admin"]!=null)
            {
                dgUsersAdmin.DataSource = ds;
                dgUsersAdmin.DataBind();
                dgUsersAdmin.Visible = true;
            }
            else
            {
                //general user search
                dgUsers.DataSource = ds;
                dgUsers.DataBind();
                dgUsers.Visible = true;
            }

            
            
            if (ds.Tables[0].Rows.Count == 0) { litMessage.Text = "No users found. Please expand the search criteria."; } else { litMessage.Text = ""; }
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
    }
}