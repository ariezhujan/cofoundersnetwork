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
    public partial class Messaging : System.Web.UI.Page
    {
        public string IFrameStartingSRC = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalUser.CheckUserLoggedIn(Page);
            if (!Page.IsPostBack)
            {
                //if a forumthreadid is passed it, open automatically in the iframe
                if (Request["forumThreadID"] != null)
                {
                    int forumThreadID = 0;
                    forumThreadID = Data.validInt(Request["forumThreadID"].ToString());
                    if (forumThreadID != 0) {
                        SearchComments(forumThreadID);
                    }
                }
                SearchThreads();
            } 
        }

        public string UserMessageAlignment(string username, bool outgoing)
        {
            GoalUser gu = GoalUser.CurrentUser(Page);
            //if the message is not from the logged in user, align to the right
            if (username == gu.name && outgoing)
            {
                return "style='display: block;'";
            }
            else if (username == gu.name && !outgoing)
            {
                return "style='display: none;'";
            }
            else if (username != gu.name && outgoing)
            {
                return "style='display: none;'";
            }
            else if (username != gu.name && !outgoing)
            {
                return "style='display: block;'";
            }
            return "";
        }

        protected void SearchThreads()
        {
            DataSet ds = Forum.GetThreads(Forum.ForumID_InternalChat, 1, 200, GoalUser.CurrentUserId(Page));
            dgForumThreads.DataSource = ds;
            dgForumThreads.DataBind();

            //if no messages inform the user
            if (ds.Tables[0].Rows.Count==0)
            {
                litMessage.Visible = true;
                divMessaging.Visible = false;
            }

            //load the first messaging thread if available
            if (hdnThreadID.Value.Trim()=="")
            {
                int forumThreadID = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SearchComments(int.Parse(ds.Tables[0].Rows[0]["id"].ToString()));
                }
            }
        }

        protected void btnAddMessage_OnClick(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() != "")
            {
                //add message
                int forumThreadID = Data.validInt(hdnThreadID.Value);
                Comment comment = new Comment();
                comment.userID = GoalUser.CurrentUserId(Page);
                comment.objectID = forumThreadID;
                comment.comment = txtMessage.Text;
                comment.objectType = Comment.objectType_Thread;
                comment.Create();

                //refresh the list of messages and threads
                SearchComments(forumThreadID);
                SearchThreads();
                txtMessage.Text = "";

                //notify the recipient of the new message
                ForumThread ft = new ForumThread(comment.objectID);
                ft.NotifyRecipient(comment, Application);
            }
            txtMessage.Focus();
        }

        protected void btnThreadView_Click(object sender, EventArgs e)
        {
            SearchComments(int.Parse(((LinkButton)sender).CommandArgument.ToString()));
            //SearchComments(int.Parse(((System.Web.UI.HtmlControls.HtmlAnchor)sender).Name));
        }

        protected void SearchComments(int forumThreadID)
        {
            DataSet ds = Comment.Get_ForObject(forumThreadID, Comment.objectType_Thread);
            dgComments.DataSource = ds;
            dgComments.DataBind();

            ForumThread ft = new ForumThread();
            ft.Load(forumThreadID);

            //load title
            GoalUser user;
            if (ft.userID == GoalUser.CurrentUserId(Page))
            {
                user = (new GoalUser(ft.userID2));
            }
            else
            {
                user = (new GoalUser(ft.userID));
            }

            hdnThreadID.Value = forumThreadID.ToString();

            //load link to user profile
            //litHeader.Text = user.name;
            //hlUserProfile.Text = "View Profile";
            //hlUserProfile.NavigateUrl = "User.aspx?id=" + user.id;

            txtMessage.Focus();

        }
    }
}