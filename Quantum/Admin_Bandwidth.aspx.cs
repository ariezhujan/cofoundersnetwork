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
using QuantumLibrary;

public partial class Admin_Bandwidth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ddlYear.Items.Add(new ListItem("2011", "2011"));
            ddlYear.Items.Add(new ListItem("2012", "2012"));
            ddlYear.Items.Add(new ListItem("2013", "2013"));
            Data.DDL_SetSelectedValue(DateTime.Now.ToString("yyyy"), ddlYear);

            ddlMonth.Items.Add(new ListItem("1", "01"));
            ddlMonth.Items.Add(new ListItem("2", "02"));
            ddlMonth.Items.Add(new ListItem("3", "03"));
            ddlMonth.Items.Add(new ListItem("4", "04"));
            ddlMonth.Items.Add(new ListItem("5", "05"));
            ddlMonth.Items.Add(new ListItem("6", "06"));
            ddlMonth.Items.Add(new ListItem("7", "07"));
            ddlMonth.Items.Add(new ListItem("8", "08"));
            ddlMonth.Items.Add(new ListItem("9", "09"));
            ddlMonth.Items.Add(new ListItem("10", "10"));
            ddlMonth.Items.Add(new ListItem("11", "11"));
            ddlMonth.Items.Add(new ListItem("12", "12"));
            Data.DDL_SetSelectedValue(DateTime.Now.ToString("MM"), ddlMonth);
        }
    }

    protected void btnBandwidthSearch_Click(object sender, EventArgs e)
    {
        grdBandwidth.DataSource = GoalUser.Get_UserBandwidth(int.Parse(ddlYear.SelectedValue), int.Parse(ddlMonth.SelectedValue));
        grdBandwidth.DataBind();
    }

    
}
