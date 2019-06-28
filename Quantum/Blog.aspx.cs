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
    public partial class Blog : System.Web.UI.Page
    {
        public string IFrameStartingSRC = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //allow admin users to create new blog posts
                if (GoalUser.CurrentUserType(Page) == GoalUser.usertype_User_Admin)
                {
                    pnlCreatePost.Visible = true;
                }
            }            
        }


        protected void btn_CreateNewPost_Click(object sender, EventArgs e)
        {
            if (txtPostName.Text.Trim() == "")
            {
                litNewPostMessage.Text = "Please enter a post name.";
                return;
            }

            //create blog thread         
            ForumThread ft = new ForumThread();
            ft.forumID = Forum.ForumID_Blog;
            ft.title = txtPostName.Text;
            ft.userID = GoalUser.CurrentUserId(Page);
            ft.Create();

            Comment comment = new Comment();
            comment.objectID = ft.ID;
            comment.objectType = Comment.objectType_Thread;
            comment.userID = ft.userID;
            comment.Create();

            ft.firstCommentID = comment.id;
            ft.Update();

            //redirect to edit the blog thread
            Page.Response.Redirect("/Forum_Comment.aspx?id=" + comment.id.ToString(), false);
        }

        
    }
}