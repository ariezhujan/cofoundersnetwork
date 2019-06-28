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
    public partial class UC_HustlerArticles : System.Web.UI.UserControl
    {
        public string IFrameStartingSRC = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Search();
            }
        }

        protected void Search()
        {
            DataSet ds = Forum.GetThreads(Forum.ForumID_Hustlers, 1, 200, 0);
            dgForumThreads.DataSource = ds;
            dgForumThreads.DataBind();
        }

        public int rowCount = 0;
        protected string CreateRows(int cols)
        {

            string footer = "</div>";
            string header = "<div class='container'>";
            rowCount++;

            if (rowCount % cols == 0) { return footer + header; } else { return ""; }
        }
    }
}