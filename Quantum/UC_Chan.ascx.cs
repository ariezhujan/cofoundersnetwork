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

public partial class UC_Chan : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            repComments.DataSource = Comment.Get_ForChan();
            repComments.DataBind();
        }
    }

    public bool IsType(object image, bool file)
    {
        if (file)
        {
            if (image.ToString() != "")
            {
                return true;
            }
        }
        else
        {
            if (image.ToString() == "")
            {
                return true;
            }
        }
        return false;
    }
}
