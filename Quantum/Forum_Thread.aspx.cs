using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class Forum_Thread : System.Web.UI.Page
    {
        int commentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            commentID = Data.validInt(Request["id"].ToString());
            if (!Page.IsPostBack && commentID != 0)
            {
                //load the comment
                Comment comment = new Comment(commentID);

                //get the thread
                ForumThread ft = new ForumThread(comment.objectID);
                litTitle.Text = ft.title;
                litComment.Text = comment.comment;

                //create link to the project founder user
                GoalUser user = new GoalUser(comment.userID);
                hlUser.Text = user.name;
                hlUser.NavigateUrl = "User.aspx?id=" + user.id;
                imgUser.ImageUrl = File.uploadedFilesDirectory + "\\" + user.image;

                //load image
                LoadCommentImage(ft);

                //display additional threads below
                if (ft.forumID == Forum.ForumID_Hustlers) { ucHustlerArticles.Visible = true; }
                if (ft.forumID == Forum.ForumID_Blog) { ucBlogArticles.Visible = true; }

                //if admin
                if (GoalUser.CurrentUserType(Page) == GoalUser.usertype_User_Admin)
                {
                    linkEdit.Visible = true;
                    linkEdit.HRef = "/Forum_Comment.aspx?ID="+ Request["id"].ToString();
                }
            }
        }

        protected void LoadCommentImage(ForumThread ft)
        {
            File file = new File(ft.imageID);

            //display the upload button if there are no files available
            if (file.id == 0)
            {
                //dgFiles.Visible = false;
                //btnUpload.Visible = true;
                imgThread.ImageUrl = File.uploadedFilesDirectory + "\\blog_no_image.jpg";
            }
            else
            {
                //hide the upload button if there already exists an uploaded file
                //dgFiles.Visible = true;
                //btnUpload.Visible = false;
                imgThread.ImageUrl = File.uploadedFilesDirectory + "\\" + file.image;
            }
        }
    }
}