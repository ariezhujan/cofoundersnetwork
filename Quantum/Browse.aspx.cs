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

public partial class Browse : System.Web.UI.Page
{
    int suggestionCount = 0;
    public string SuggestionCount()
    {
        suggestionCount++;
        return suggestionCount.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //get passed value
            string value = "1";
            if (Request["value"] != null)
            {
                value = Request["value"].ToString().Trim().ToLower();
            }

            //for category use category tags, else for file types (game, animation, soundboard, popular, new uploads)
            int categoryID = 0;
            if (int.TryParse(value, out categoryID))
            {
                //display files
                DataSet ds = File.GetBrowseCategory_Suggestions_Many(categoryID);
                dlFiles.DataSource = ds;
                dlFiles.DataBind();

                //display category header
                litTitle.Text = ds.Tables[1].Rows[0]["CategoryName"].ToString();
            }
            else
            {
                int fileType;
                //get popular files of type 'games'
                if (value == "games")
                {
                    litTitle.Text = "Popular Games";
                    fileType = File.fileType_game;
                }
                else if (value == "animations")
                {
                    litTitle.Text = "Popular Animations";
                    fileType = File.fileType_animation;
                }
                else if (value == "soundboards")
                {
                    litTitle.Text = "Popular Soundboards";
                    fileType = File.fileType_soundboard;
                }
                else if (value == "videos")
                {
                    litTitle.Text = "Popular Videos";
                    fileType = File.fileType_video;
                }
                else if (value == "images")
                {
                    litTitle.Text = "Popular Images";
                    fileType = File.fileType_image;
                }
                else if (value == "music")
                {
                    litTitle.Text = "Popular Music";
                    fileType = File.fileType_musicAlbum;
                }
                else 
                {
                    litTitle.Text = "Popular Uploads";
                    fileType = 0;
                }
                dlFiles.DataSource = File.GetPopular_Many(fileType);
                dlFiles.DataBind();
            }

            Page.Title = "MegaSWF - " + litTitle.Text;
        }
    }
}
