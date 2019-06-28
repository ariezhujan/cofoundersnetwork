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
    public partial class User_Edit : System.Web.UI.Page
    {
        int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalUser.CheckUserLoggedIn(Page);

            //get userid to edit. If admininstrator and userid passed in use that, otherwise use the current user's ID.
            if (Request["id"] != null && GoalUser.CurrentUserType(Page) == GoalUser.usertype_User_Admin)
            {
                userID = Data.validInt(Request["id"].ToString());
                pnlDeleteUser.Visible = true;
            }
            else
            {
                userID = GoalUser.CurrentUserId(Page);
            }
            
            if (!Page.IsPostBack)
            {
                //populate DDLs
                int x = 10;
                while (x < 100) { ddlAge.Items.Add(x.ToString()); x++; }

                //load ddls
                rblIndustry.DataSource = ObjectListValue.GetListValues("Industry", 0, 0, true);
                rblIndustry.DataValueField = "Name";
                rblIndustry.DataTextField = "Name";
                rblIndustry.DataBind();

                rblBusinessStage.DataSource = ObjectListValue.GetListValues("BusinessStage", 0, 0, true);
                rblBusinessStage.DataValueField = "Name";
                rblBusinessStage.DataTextField = "Name";
                rblBusinessStage.DataBind();

                //load the user's details
                GoalUser user = new GoalUser(userID);
                txtEmail.Text = user.username;
                txtName.Text = user.name;
                txtAbout.Text = user.about;
                ddlCountry.Value= user.country;
                txtWebsite.Text = user.website;
                ddlAge.SelectedValue = user.age.ToString();
                rblIndustry.SelectedValue = user.industry;
                rblBusinessStage.SelectedValue = user.businessStage;
                rblStartUpExperience.SelectedValue = user.startUpExperience.ToString();
                chkAcceptEmail.Checked = user.acceptEmail;
                chkLookingToCollaborate.Checked = user.lookingToCollaborate;
                chkLookingToInvest.Checked = user.lookingToInvest;
                if (user.amountToInvestUSD!=0) { txtInvestmentAmountUSD.Text = user.amountToInvestUSD.ToString(); }
                if (user.hourstoCollaborate != 0) { txtHoursToCollaborate.Text = user.hourstoCollaborate.ToString(); }
                user.position = txtPosition.Text;

                LoadUserImage();

                //load misc lists
                ucObjectListValue_Skills.ObjectID = user.id;
                ucObjectListValue_Skills.ObjectType = ObjectListValue.ObjectType_userID;
                ucObjectListValue_Skills.ValueType = "Skill";
                ucObjectListValue_Skills.list1 = "Skill";
                ucObjectListValue_Skills.listValueID1_Name = "Skill";
                ucObjectListValue_Skills.enableEditing = true;

                ucObjectListValue_Industries.ObjectID = user.id;
                ucObjectListValue_Industries.ObjectType = ObjectListValue.ObjectType_userID;
                ucObjectListValue_Industries.ValueType = "Industry";
                ucObjectListValue_Industries.list1 = "Industry";
                ucObjectListValue_Industries.listValueID1_Name = "Industry";
                ucObjectListValue_Industries.enableEditing = true;

                ucObjectListValue_Education.ObjectID = user.id;
                ucObjectListValue_Education.ObjectType = ObjectListValue.ObjectType_userID;
                ucObjectListValue_Education.ValueType = "Education";
                ucObjectListValue_Education.stringValue1_Name = "Institution";
                ucObjectListValue_Education.stringValue2_Name = "Degree";
                ucObjectListValue_Education.enableEditing = true;

                ucObjectListValue_Certification.ObjectID = user.id;
                ucObjectListValue_Certification.ObjectType = ObjectListValue.ObjectType_userID;
                ucObjectListValue_Certification.ValueType = "Certification";
                ucObjectListValue_Certification.stringValue1_Name = "Institution";
                ucObjectListValue_Certification.stringValue2_Name = "Certificate";
                ucObjectListValue_Certification.enableEditing = true;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            //if the passwords match
            if (txtPassword.Text != txtPassword2.Text)
            {
                litPasswordMessage.Text = "Passwords do not match.";
            }
            else
            if(txtPassword.Text.Trim()=="")
            {
                litPasswordMessage.Text = "A password is required.";
            }
            else
            {
                //update the password
                GoalUser user = new GoalUser(userID);
                user.password = txtPassword.Text;
                user.Update();
                litPasswordMessage.Text = "Password has been updated.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GoalUser user = new GoalUser(userID);

            if (!GoalUser.UsernameAvailable(txtEmail.Text) && txtEmail.Text != user.username)
            {
                //show error that the email is unavailable
                litUpdateMessage.Text = "The email address: " + txtEmail.Text + " is already attatched to an account";
            }
            else
            {
                //update the user's details   
                //reset that the email is confirmed if the email is changed.
                //TODO send email confirmation email again
                if (user.username.Trim() != txtEmail.Text.Trim()) { user.emailAddressConfirmed = false; }            
                user.username = txtEmail.Text;
                user.name = txtName.Text;
                user.about = Data.CleanHTMLPassedIn(txtAbout.Text);
                user.country = ddlCountry.Value; 
                user.website = txtWebsite.Text;
                user.age = Data.validInt(ddlAge.SelectedValue);
                user.industry = rblIndustry.SelectedValue;
                user.businessStage = rblBusinessStage.SelectedValue;
                user.startUpExperience = Data.validInt(rblStartUpExperience.SelectedValue);
                user.acceptEmail = chkAcceptEmail.Checked;
                user.lookingToCollaborate = chkLookingToCollaborate.Checked;
                user.lookingToInvest = chkLookingToInvest.Checked;
                user.amountToInvestUSD = Data.validInt(txtInvestmentAmountUSD.Text);
                user.hourstoCollaborate = Data.validInt(txtHoursToCollaborate.Text);
                user.position = txtPosition.Text;

                user.Update();

                litUpdateMessage.Text = "Profile Updated";
            }
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            //remove any existing image
            DataSet ds = File.GetFilesForUser(userID, 0, false);

            //display the upload button if there are no files available
            if (ds.Tables[0].Rows.Count > 0)
            {
                File f = new File((int)(ds.Tables[0].Rows[0]["id"]));
                f.Delete(Server);
            }

            int fileID = 0;
            string fileLocation = "";
            string ext = "";
            //filesize 1,000,000 is 1 MB
            try
            {
                ext = FileUploader.FileName.ToLower();
            }
            catch (Exception ex)
            {
                litFileUploadMessage.Text = "Please select a file.";
            }
            int index = ext.LastIndexOf(".");
            ext = ext.Substring(ext.LastIndexOf(".")+1, ext.Length - (ext.LastIndexOf(".")+1 ));
            if (ext != "jpg" &&  ext != "jpeg" && ext != "png")
            {
                litFileUploadMessage.Text = "Please upload a JPG or PNG file.";
                return;
            }
            litFileUploadMessage.Text = File.UploadFile(FileUploader, "", HttpContext.Current.Server, Page, 1000000, ref fileID, ref fileLocation, true, "");
            File file = new File(fileID);
            file.userID = userID;
            file.Update();

            GoalUser user = new GoalUser(userID);
            user.image = file.image;
            user.Update();

            LoadUserImage();

            //scroll to view the image upload section as partial post back is not being used.
            //TODO replace the image upload functionality with a control that can support partial postback.
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "location.hash = \"#anchorUploadPhoto\";", true);
        }

        //protected void btnDeleteFile_Click(object sender, EventArgs e)
        //{
        //    //delete the file
        //    int fileID = 0;
        //    fileID = Data.validInt(((Button)sender).CommandArgument.ToString());
        //    File file = new File(fileID);
        //    file.Delete(Server);

        //    //remove image from the user object
        //    GoalUser user = new GoalUser(userID);
        //    user.image = "";
        //    user.Update();

        //    LoadUserImage();

        //    litFileUploadMessage.Text = "File deleted.";
        //}

        /// <summary>
        /// Display the users image on the page
        /// </summary>
        protected void LoadUserImage()
        {
            DataSet ds = File.GetFilesForUser(userID, 0, false);
            //dgFiles.DataSource = ds;
            //dgFiles.DataBind();

            //display the upload button if there are no files available
            if (ds.Tables[0].Rows.Count == 0) {
                //dgFiles.Visible = false;
                //btnUpload.Visible = true;
                imgUser.ImageUrl = File.uploadedFilesDirectory + "\\user_no_image.jpg";
            }
            else
            {
                //hide the upload button if there already exists an uploaded file
                //dgFiles.Visible = true;
                //btnUpload.Visible = false;
                imgUser.ImageUrl = File.uploadedFilesDirectory + "\\" + ds.Tables[0].Rows[0]["image"].ToString();
            }
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            //delete the project
            GoalUser user = new GoalUser(userID);
            user.deletedDate = DateTime.Now;
            user.Update();

            Page.Response.Redirect("/User_Search.aspx?admin=1", false);
        }
    }
}