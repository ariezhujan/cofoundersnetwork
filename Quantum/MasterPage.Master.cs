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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public bool HeaderVisible
        {
            get { return this.phHeader.Visible; }
            set { this.phHeader.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if not live hide menus
                if (ConfigurationSettings.AppSettings["siteIsLive"].ToString() == "false")
                {
                    //pnlMenu.Visible = false;
                    contentFooter.Visible = false;
                }

                if (GoalUser.UserLoggedIn(Page))
                {
                    GoalUser user = GoalUser.CurrentUser(Page);
                    litUsername_Mobile.Text = user.name;
                    litUsername.Text = user.name;
                    imgUser.ImageUrl = File.uploadedFilesDirectory + "\\" + user.image;
                    phSignedIn_Mobile.Visible = true;
                    phSignedOut_Mobile.Visible = false;
                    phSignedIn.Visible = true;
                    phSignedOut.Visible = false;
                    //hlLogo.NavigateUrl = "user_welcome.aspx";
                }
                else
                {
                    phSignedIn_Mobile.Visible = false;
                    phSignedOut_Mobile.Visible = true;
                    phSignedIn.Visible = false;
                    phSignedOut.Visible = true;                    
                }
                hlLogo.NavigateUrl = "default.aspx";
            }
        }
    }
}