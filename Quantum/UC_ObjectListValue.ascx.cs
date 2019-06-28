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
    public partial class UC_ObjectListValue : System.Web.UI.UserControl
    {
        public bool enableEditing = false;

        public int ObjectID = 0;
        public int ObjectType = 0;
        public string ValueType = "";

        public string listValueID1_Name = "";
        public string list1 = "";
        public bool list1IncPreviouslyUsed = false;
        public string list1RegularExpression = "\\d+";
        public string list1RegularExpressionErrorMessage = "Enter numbers only. e.g. 5000";
        public string listValueID2_Name = "";
        public string list2 = "";
        public bool list2IncPreviouslyUsed = false;
        public string list2RegularExpression = "\\d+";
        public string list2RegularExpressionErrorMessage = "Enter numbers only. e.g. 5000";
        public string stringValue1_Name = "";
        public string stringValue2_Name = "";
        public string stringValue3_Name = "";
        public string intValue1_Name = "";
        public string intValue2_Name = "";
        public string decValue1_Name = "";
        public string dateValue1_Name;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                //if editing is enabled, display the input fields and the delete button
                if (enableEditing)
                {
                    dgValues.Columns[dgValues.Columns.Count - 1].Visible = true;   //show delete button
                    pnlInput.Visible = true; //show fields for creating new records
                }

                //regular expressions
                revIntValue1.ValidationExpression = list1RegularExpression;
                revIntValue1.ErrorMessage = list1RegularExpressionErrorMessage;
                revIntValue2.ValidationExpression = list2RegularExpression;
                revIntValue2.ErrorMessage = list2RegularExpressionErrorMessage;

                //store in hidden fields
                hfObjectID.Value = ObjectID.ToString();
                hfObjectType.Value = ObjectType.ToString();
                hfValueType.Value = ValueType;
                hflistValueID1_Name.Value = listValueID1_Name.ToString();
                hflist1.Value = list1.ToString();
                hflist1IncPreviouslyUsed.Value = list1IncPreviouslyUsed.ToString();
                hflistValueID2_Name.Value = listValueID2_Name.ToString();
                hflist2.Value = list2.ToString();
                hflist2IncPreviouslyUsed.Value = list2IncPreviouslyUsed.ToString();
                hfstringValue1_Name.Value = stringValue1_Name.ToString();
                hfstringValue2_Name.Value = stringValue2_Name.ToString();
                hfstringValue3_Name.Value = stringValue3_Name.ToString();
                hfintValue1_Name.Value = intValue1_Name.ToString();
                hfintValue2_Name.Value = intValue2_Name.ToString();
                hfdecValue1_Name.Value = decValue1_Name.ToString();
                if(dateValue1_Name!=null){ hfdateValue1_Name.Value = dateValue1_Name.ToString(); }

                //load previously created records for the object
                LoadValues();

                //load items into the drop down lists            
                LoadDDLValues(ddlList1, list1, litMessageddlList1, list1IncPreviouslyUsed);
                LoadDDLValues(ddlList2, list2, litMessageddlList2, list2IncPreviouslyUsed);
            }
            else
            {
                ObjectID = Data.validInt(hfObjectID.Value);
                ObjectType = Data.validInt(hfObjectType.Value);
                ValueType = hfValueType.Value;
                listValueID1_Name = hflistValueID1_Name.Value;
                list1 = hflist1.Value;
                list1IncPreviouslyUsed = Data.validBool(hflist1IncPreviouslyUsed.Value);
                listValueID2_Name = hflistValueID2_Name.Value;
                list2 = hflist2.Value;
                list2IncPreviouslyUsed = Data.validBool(hflist2IncPreviouslyUsed.Value);
                stringValue1_Name = hfstringValue1_Name.Value;
                stringValue2_Name = hfstringValue2_Name.Value;
                stringValue3_Name = hfstringValue3_Name.Value;
                intValue1_Name = hfintValue1_Name.Value;
                intValue2_Name = hfintValue2_Name.Value;
                decValue1_Name = hfdecValue1_Name.Value;
                dateValue1_Name = hfdateValue1_Name.Value;
            }
        }

        /// <summary>
        /// Load the values into the drop down list based on the list and if the user has used the list option before.
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="list"></param>
        protected void LoadDDLValues(System.Web.UI.HtmlControls.HtmlSelect ddl, string list, Literal litDDLMessage, bool includePreviouslyUsed)
        {
            ddl.DataSource = ObjectListValue.GetListValues(list, ObjectID, ObjectType, includePreviouslyUsed);
            ddl.DataValueField = "ID";
            ddl.DataTextField = "Name";
            ddl.DataBind();

            //hide the option if no further options availble
            if (ddl.Items.Count == 0)
            {
                ddl.Visible = false;
                litDDLMessage.Text = "No options remaining.";
            }
            else
            {
                ddl.Visible = true;
                litDDLMessage.Text = "";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if ((listValueID1_Name!="" && ddlList1.Items.Count == 0)
                || (listValueID2_Name != "" && ddlList2.Items.Count == 0))
            {
                litMessage.Text = "No more items may be added.";
                return;
            }
            else if ((stringValue1_Name != "" && txtStringValue1.Text.Trim() == "")
                || (stringValue2_Name != "" && txtStringValue2.Text.Trim() == "")
                || (stringValue3_Name != "" && txtStringValue3.Text.Trim() == "")
                || (intValue1_Name != "" && txtIntValue1.Value.Trim() == "")
                || (intValue2_Name != "" && txtIntValue2.Value.Trim() == "")
                || (decValue1_Name != "" && txtDecValue1.Text.Trim() == "")
                || (dateValue1_Name != "" && (txtDateValue1.Text.Trim() == "" || Data.validDateTime(txtDateValue1.Text)== Data.defaultDateTime())))
            {
                litMessage.Text = "Please enter a value.";
            }
            else
            {
                ObjectListValue olv = new ObjectListValue(ObjectID, ObjectType, ValueType);
                olv.listValueID1 = Data.validInt(ddlList1.Value);
                olv.listValueID2 = Data.validInt(ddlList2.Value);
                olv.stringValue1 = txtStringValue1.Text;
                olv.stringValue2 = txtStringValue2.Text;
                olv.stringValue3 = txtStringValue3.Text;
                olv.intValue1 = Data.validInt(txtIntValue1.Value);
                olv.intValue2 = Data.validInt(txtIntValue2.Value);
                olv.decValue1 = Data.validDecimal(txtDecValue1.Text);
                olv.dateValue1 = Data.validDateTime(txtDateValue1.Text);
                olv.Create();
                olv.Update();

                UpdateMasterRecord();
                LoadValues();
            }
        }

        protected void LoadValues()
        {
            //only display columns that have data
            LoadColumnsVisible(listValueID1_Name, 0, trList1, litListTitle1);
            LoadColumnsVisible(listValueID2_Name, 1, trList2, litListTitle2);
            LoadColumnsVisible(stringValue1_Name, 2, trString1, litStringTitle1);
            LoadColumnsVisible(stringValue2_Name, 3, trString2, litStringTitle2);
            LoadColumnsVisible(stringValue3_Name, 4, trString3, litStringTitle3);
            LoadColumnsVisible(intValue1_Name, 5, trInt1, litIntTitle1);
            LoadColumnsVisible(intValue2_Name, 6, trInt2, litIntTitle2);
            LoadColumnsVisible(decValue1_Name, 7, trDec1, litDecTitle1);
            LoadColumnsVisible(dateValue1_Name, 8, trDate1, litDateTitle1);

            DataSet ds = ObjectListValue.GetObjectListValues(ObjectID, ObjectType, ValueType);
            dgValues.DataSource = ds;
            dgValues.DataBind();
            //hide table if no rows
            litValues.Text = "";
            if (ds.Tables[0].Rows.Count == 0)
            {
                dgValues.Visible = false;
                litValues.Text = "No entries";
            }
            else
            { dgValues.Visible = true; } 

            //reset the values
            litMessage.Text = "";
            txtStringValue1.Text = "";
            txtStringValue2.Text = "";
            txtStringValue3.Text = "";
            txtIntValue1.Value = "";
            txtIntValue2.Value = "";
            txtDecValue1.Text = "";
            txtDateValue1.Text = "";
        }

        /// <summary>
        /// Update some other master record if necessary with the selected values. Useful for caching if the values are used in a search.
        /// </summary>
        private void UpdateMasterRecord()
        {
            //if a user's skills are being updated, update the skills value against the user's record
            if (ObjectType == ObjectListValue.ObjectType_userID && list1 == "Skill")
            {
                DataSet dsSkills = ObjectListValue.GetObjectListValues(ObjectID, ObjectListValue.ObjectType_userID, "Skill");
                int z = dsSkills.Tables[0].Rows.Count - 1;
                string skills = "";
                while (z >= 0)
                {
                    skills = skills + ", " + dsSkills.Tables[0].Rows[z]["listValue1"].ToString();
                    z--;
                }
                if (skills != "") { skills = skills.Substring(2, skills.Length - 2); }
                GoalUser user = new GoalUser(ObjectID);
                user.skills = skills;
                user.Update();
            }
        }

        /// <summary>
        /// Display columns for which there is a header supplied to the control
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="columnIndex"></param>
        protected void LoadColumnsVisible(string headerText, int columnIndex, Control tr, Literal litInputControl)
        {
            //display input and table column if data input is allowed
            if (headerText != "" && headerText != null) {
                dgValues.Columns[columnIndex].Visible = true;
                dgValues.Columns[columnIndex].HeaderText = headerText;
                tr.Visible = true;
                litInputControl.Text = headerText;
            }
            else
            {
                //hide input
                tr.Visible = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //delete the file
            int ObjectListValueID = 0;
            ObjectListValueID = Data.validInt(((Button)sender).CommandArgument.ToString());
            ObjectListValue olv = new ObjectListValue(ObjectListValueID);
            olv.Delete();

            UpdateMasterRecord();
            LoadValues();
        }
    }
}