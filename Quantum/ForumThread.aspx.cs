using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using megaswfLibrary;

public partial class ForumThread : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //get thread id
            int threadID = int.Parse(Request["threadID"].ToString());
            megaswfLibrary.ForumThread ft = new megaswfLibrary.ForumThread();
            ft.Load(threadID);          

            //title
            litTitle.Text = ft.title;

            //comments
            CommentsUC.objectID = ft.ID;
            CommentsUC.objectType = Comment.objectType_Thread;
        }
    }
}
