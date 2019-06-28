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

public partial class UC_Suggestions : System.Web.UI.UserControl
{
    public int fileID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //get the file id passed
        if (Request["fileID"] != null)
        {
            int.TryParse(Request["fileID"].ToString(), out fileID);
        }

        //if fileid passed, store in pageview
        if (fileID != 0)
        {
            hdnFileID.Value = fileID.ToString();
        }

        //get the file
        File file = File.Load_FromCache(fileID, Page);

        //remove google ads if file has been reported
        if (file.count_report > 0)
        {
            phAds_Square.Text = "";
        }

        if (!Page.IsPostBack)
        {
            DataSet ds = File.Load_FromCache_Suggestions(fileID, Page);

            //store first suggestion if available
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnFirstSuggestion.Value = ds.Tables[0].Rows[0]["id"].ToString();
            }

            repSuggestions.DataSource = ds;
            repSuggestions.DataBind();
        }

        //display suggestions links
        if (file.fileType == File.fileType_game)
        {
            pnlTypeSuggestions_Games.Visible = true;
        }
        else if (file.fileType == File.fileType_animation)
        {
            pnlTypeSuggestions_Animations.Visible = true;
        }
        else if (file.fileType == File.fileType_video)
        {
            pnlTypeSuggestions_Videos.Visible = true;
        }
        else if (file.fileType == File.fileType_image)
        {
            pnlTypeSuggestions_Images.Visible = true;
        }
    }

    public string DisplayThumbVideo(object fileID_object)
    {
        int fileID_int = (int)fileID_object;
        
        //get file
        File file = File.Load_FromCache(fileID_int, Page);

        //see the thumb video has been created
        if (file.location_thumb_video_9070_exists)
        {
            return "true";
        }
        else
        {
            //open thread to create thumb video
            return "false";
        }
    }

    public int GetFirstSuggestionID()
    {
        try
        {
            return int.Parse(hdnFirstSuggestion.Value);
        }
        catch(Exception ex)
        {
            megaswfLibrary.Event.SaveEvent("GetFirstSuggestionID failed - hdnFirstSuggestion.Value: " + hdnFirstSuggestion.Value + " hdnFileID.Value: " + hdnFileID.Value, Event.Type_Error);
        }
        return 0;
    }

    int suggestionCount = 0;
    public string SuggestionCount()
    {
        suggestionCount++;
        return suggestionCount.ToString();
    }


    /// <summary>
    /// Display square ad in suggestions
    /// </summary>
    private int count = 0;
    public string DisplayAds()
    {
        count++;

        if (count == 4)
        {
            return "</tr><tr><td colspan='2'>" + phAds_Square.Text + "</td></tr>";
        }
        return "";
    }


    /// <summary>
    /// TRs for displaying in 2 columns
    /// </summary>
    private int TR_count = 0;
    public string TR_Start()
    {
        TR_count++;

        if (TR_count % 2 == 1)
        {
            return "</tr><tr>";
        }
        return "";
    }
}
