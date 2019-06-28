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


public partial class Games : System.Web.UI.Page
{
    public string tags = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //get search tags
            if (Request["tags"] != null)
            {
                tags = Request["tags"].ToString();
            }

            //if home page
            if (tags == "")
            {
                this.Title = "Best Games Of All Time";
            }
            else
            {
                this.Title = "Best " + tags.Substring(0, 1).ToUpper() + tags.Substring(1, tags.Length - 1) + " Games";
            }
        }
    }
}
