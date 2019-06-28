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

public partial class UC_BrowseCategory : System.Web.UI.UserControl
{
    public int browseCategoryID = 0;
    public int displayCount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = File.GetBrowseCategory_Suggestions(browseCategoryID);
            dlFiles.DataSource = ds;
            dlFiles.DataBind();

            litCategoryName.Text = ds.Tables[1].Rows[0]["CategoryName"].ToString();
            if (litCategoryName.Text.Trim() != "")
            {
                litCategoryName.Text = litCategoryName.Text + "<br />";
            }
        }
    }
}
