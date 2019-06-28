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
    public partial class Forum_Comment : System.Web.UI.Page
    {
        public int commentID = 0;
        public int forumThreadID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GoalUser.CheckUserLoggedIn(Page);

            commentID = Data.validInt(Request["id"].ToString());
            if (!Page.IsPostBack && commentID !=0)
            {
                //load the comment
                Comment comment = new Comment(commentID);

                //check if the user is allowed to edit the comment
                if (comment.userID!=GoalUser.CurrentUserId(Page) &&  GoalUser.CurrentUserType(Page) != GoalUser.usertype_User_Admin)
                { return; }

                //get the thread
                ForumThread ft = new ForumThread(comment.objectID);
                forumThreadID = ft.ID;  
                txtTitle.Text = ft.title;
                txtComment.Text = comment.comment;
                    
                LoadCommentImage(ft);
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment(commentID);
            comment.comment = txtComment.Text;
            comment.Update();

            ForumThread ft = new ForumThread(comment.objectID);
            ft.title = txtTitle.Text;
            ft.Update();

            litUpdateMessage.Text = "Comment Updated";
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {           
            int fileID = 0;
            string fileLocation = "";
            //filesize 1,000,000 is 1 MB

            string ext;
            try
            { 
                ext = FileUploader.FileName.ToLower();
            }
            catch (Exception ex)
            {
                litFileUploadMessage.Text = "Please select a file.";
                return;
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
            file.userID = GoalUser.CurrentUserId(Page);
            file.Update();

            Comment comment = new Comment(commentID);
            ForumThread ft = new ForumThread(comment.objectID);
            ft.imageID = file.id;
            ft.Update();

            LoadCommentImage(ft);
        }

        /// <summary>
        /// Display the users image on the page
        /// </summary>
        protected void LoadCommentImage(ForumThread ft)
        {
            File file = new File(ft.imageID);

            //display the upload button if there are no files available
            if (file.id == 0) {
                //dgFiles.Visible = false;
                //btnUpload.Visible = true;
                imgUser.ImageUrl = File.uploadedFilesDirectory + "\\blog_no_image.jpg";
            }
            else
            {
                //hide the upload button if there already exists an uploaded file
                //dgFiles.Visible = true;
                //btnUpload.Visible = false;
                imgUser.ImageUrl = File.uploadedFilesDirectory + "\\" + file.image;
            }
        }

        protected void btnDeletePost_Click(object sender, EventArgs e)
        {
            //delete the comment 
            Comment comment = new Comment(commentID);
            comment.deletedDate = DateTime.Now;
            comment.Update();

            //delete the thread if the comment is the first comment in the thread
            ForumThread ft = new ForumThread(comment.objectID);
            if (ft.firstCommentID == comment.id) { ft.deletedDate = DateTime.Now; ft.Update(); }

            Page.Response.Redirect("/default.aspx", false);
        }
    }
}