using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Tag : System.Web.UI.UserControl
{
    private List<Int32> _tagsInc;
    public List<Int32> tagsInc
    {
        get 
        {
            if (_tagsInc == null)
            {
                GetListOfTagsFromView(ref hdnTagsInc);
                return _tagsInc;
            }else
            {
                return _tagsInc;
            }
        }
        set
        {
            _tagsInc = value;

            SaveListOfTagsToView(ref hdnTagsInc);
        }
    }


    //Saves to the view
    private void SaveListOfTagsToView(ref HiddenField hdn)
    {
        hdn.Value = "";
        foreach (Int32 tagID in tagsInc)
        {
            hdn.Value = hdn.Value + tagID + "|";
        }
        hdn.Value = hdn.Value.Substring(0, hdn.Value.Length - 1);
    }

    //Gets from the view
    private void GetListOfTagsFromView(ref HiddenField hdn)
    {
        _tagsInc = new List<int>();

        //get hdn value
        string[] splitVal = hdn.Value.Split('|');

        int count = 0;
        while (count <= splitVal.Length - 1)
        {
            //for each between | add to list 
            if (splitVal[count].ToString() != "")
            {
                tagsInc.Add(int.Parse(splitVal[count]));
            }
            count++;
        }
    }

    private int _tagID;
    public int tagID
    {
        get { return int.Parse(hdnTagID.Value); }
        set
        {
            _tagsInc = null;
            _tagID = value;
            hdnTagID.Value = _tagID.ToString();

            //add to tags to include
            tagsInc.Add(value);

            SaveListOfTagsToView(ref hdnTagsInc);
        }
    }

    private string _name;
    public string name
    {
        get { return _name; }  
        set{
            _name=value;
            btnSearch.Text = _name;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _tagsInc = new List<int>();
        }
    }

    protected void btnHide_Click(object sender, EventArgs e)
    {
        divGrid.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //List tags specific to quantum
        search();

        //display the tags being included
        litHeader.Text = "";
        foreach (Int32 tID in tagsInc)
        {
            litHeader.Text = litHeader.Text + megaswfLibrary.File.GetTagByID(tID) + "|";
        } 
    }


    public void search()
    {
        divGrid.Visible = true;


        //get tagsInc of parent tag (if exists)
        int count = 0;
        Control c = this.Parent;
        while (count < 10 && c != null)
        {
            if (c.GetType().ToString().Contains("tag"))
            {
                if (c.FindControl("hdnTagsInc") != null)
                {
                    HiddenField hdn = (HiddenField)c.FindControl("hdnTagsInc");
                    hdnTagsInc.Value = hdn.Value;
                    _tagsInc = null;
                    tagsInc.Add(this.tagID);
                    SaveListOfTagsToView(ref hdnTagsInc);
                    count = 10;
                }
            }            
            
            c = c.Parent;
            count++;
        }

        //get tags to include
        DataTable tags;
        tags = new DataTable("Items");
        tags.Columns.Add("TagID", typeof(Int32));
        foreach (Int32 tID in tagsInc)
        {
            tags.Rows.Add(tID);
        } 
        

        //List tags specific to quantum (multiple include/exclude)
        DataSet ds;
        ds = megaswfLibrary.File.GetLinks_Specific_Multi_TagsIgnore(tags);
        gridTags_Specific_Multi.DataSource = ds;
        gridTags_Specific_Multi.DataBind();

        //List tags general to quantum (multiple include/exclude)
        ds = megaswfLibrary.File.GetLinks_General_Multi_TagsIgnore(tags);
        gridTags_General_Multi.DataSource = ds;
        gridTags_General_Multi.DataBind();
    }
}