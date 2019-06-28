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
    public partial class User : System.Web.UI.Page
    {
        /// <summary>
        /// Display a value other than nothing.
        /// </summary>
        /// <param name="lit"></param>
        /// <param name="replaceValue"></param>
        protected void ReplaceEmptyValues(Literal lit, string replaceValue)
        {
            if (lit.Text.Trim() == "" || lit.Text.Trim() == "0")
            {
                lit.Text = replaceValue;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //get the user
                int userID = Data.validInt(Request["id"]);
                if (userID == 0) { userID = GoalUser.CurrentUserId(Page); }
                if (userID != 0)
                {
                    GoalUser user = new GoalUser(userID);

                    litName.Text = user.name;
                    litAge.Text = user.age.ToString();
                    litBusinessStage.Text = user.businessStage;
                    litStartUpExperience.Text = user.startUpExperience.ToString();
                    litIndustry.Text = user.industry;
                    litAbout.Text = user.about;
                    litCountry.Text = user.country;
                    litLastVisitDate.Text = user.lastLogin.ToString("dd/MM/yyyy");
                    litJoined.Text = user.createdDate.ToString("dd/MM/yyyy");

                    //image
                    DataSet ds = File.GetFilesForUser(userID, 0, false);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        imgUser.ImageUrl = File.uploadedFilesDirectory + "\\user_no_image.jpg";
                    }
                    else
                    {
                        imgUser.ImageUrl = File.uploadedFilesDirectory + "\\" + ds.Tables[0].Rows[0]["image"].ToString();
                    }

                    //load projects
                    dgProjects.DataSource = Project.GetProjects(userID);
                    dgProjects.DataBind();

                    //send userid to the contact form
                    ucUserContact.userID = user.id;

                    //send userid to the report form
                    ucUserReport.userID = user.id;

                    //load misc lists
                    //ucObjectListValue_Skills.ObjectID = user.id;
                    //ucObjectListValue_Skills.ObjectType = ObjectListValue.ObjectType_userID;
                    //ucObjectListValue_Skills.ValueType = "Skills";
                    //ucObjectListValue_Skills.list1 = "Skills";
                    //ucObjectListValue_Skills.listValueID1_Name = "Skill";

                    //load into lit
                    DataSet dsSkills = ObjectListValue.GetObjectListValues(user.id, ObjectListValue.ObjectType_userID, "Skill");
                    int z = dsSkills.Tables[0].Rows.Count-1;
                    while (z >= 0)
                    {
                        litSkills.Text = litSkills.Text + ", " + dsSkills.Tables[0].Rows[z]["listValue1"].ToString();
                        z--;
                    }
                    if (litSkills.Text != "") { litSkills.Text = litSkills.Text.Substring(2, litSkills.Text.Length - 2); }

                    ucObjectListValue_Education.ObjectID = user.id;
                    ucObjectListValue_Education.ObjectType = ObjectListValue.ObjectType_userID;
                    ucObjectListValue_Education.ValueType = "Education";
                    ucObjectListValue_Education.stringValue1_Name = "Institution";
                    ucObjectListValue_Education.stringValue2_Name = "Degree";

                    ucObjectListValue_Certification.ObjectID = user.id;
                    ucObjectListValue_Certification.ObjectType = ObjectListValue.ObjectType_userID;
                    ucObjectListValue_Certification.ValueType = "Certification";
                    ucObjectListValue_Certification.stringValue1_Name = "Institution";
                    ucObjectListValue_Certification.stringValue2_Name = "Certificate";

                    //if empty, display value
                    ReplaceEmptyValues(litBusinessStage, "Unavailable");
                    ReplaceEmptyValues(litStartUpExperience, "Unavailable");
                    ReplaceEmptyValues(litIndustry, "Unavailable");
                    ReplaceEmptyValues(litAbout, "No details are available.");
                    ReplaceEmptyValues(litCountry, "Unavailable");
                    ReplaceEmptyValues(litSkills, "Unavailable");
                    ReplaceEmptyValues(litAge, "Unavailable");
                }
            }
        }
    }
}