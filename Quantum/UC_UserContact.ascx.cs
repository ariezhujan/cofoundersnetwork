using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class UC_UserContact : System.Web.UI.UserControl
    {
        public int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { hfUserID.Value = userID.ToString(); }
            //if the user viewing is not the user who owns the project, or the user is not logged in
            if (userID == GoalUser.CurrentUserId(Page) || !GoalUser.UserLoggedIn(Page))
            {
                pnlContact.Visible = false; //don't display option to contact
            }
        }

        protected void btnContact_Click(object sender, EventArgs e)
        {
            userID = int.Parse(hfUserID.Value);
            //get the project id
            if (userID != 0)
            {
                if (txtMessage.Text.Trim() == "") { litContactMessage.Text = "Please enter a message."; return; }

                //create message thread
                ForumThread ft = new ForumThread();
                ft.forumID = Forum.ForumID_InternalChat;
                ft.userID = GoalUser.CurrentUserId(Page);
                ft.userID2 = userID;
                ft.title = "Chat";
                ft.Create();

                //create message 
                Comment comment = new Comment();
                comment.userID = GoalUser.CurrentUserId(Page);
                comment.objectID = ft.ID;
                comment.comment = txtMessage.Text;
                comment.objectType = Comment.objectType_Thread;
                comment.Create();

                //notify the recipient of the new message
                ft.NotifyRecipient(comment, Application);

                //redirect to the messaging page and open the new thread
                ft.RedirectToInternalChat(Page);
            }
        }
    }
}