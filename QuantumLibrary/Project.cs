using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for Project
    /// </summary>
    public class Project
    {
        private int ID = 0;
              
        public string ProjectID = "";
        public string Name = "";
        public string Description = "";
        public string Summary = "";
        public string Deliverables = "";
        public string Status = "";
        public string UseOfFunds = "";
        public string RisksAndChallenges = "";
        public string FundingAim = "";
        public string BusinessModel = "";
        public string Industry = "";
        public string BusinessStage = "";
        public int UserID_Founder = 0;
        public string CountryIncorporated = "";
        public int InvestmentAmountRequiredUSD = 0;
        public int InvestmentAmountMinimumUSD = 0;
        public int InvestmentAmountRaisedUSD = 0;


        public int id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }



        /// <summary>
        /// Constructior
        /// </summary>
        /// <param name="Project"></param>
        /// <param name="pass"></param>
        public Project(string name)
        {
            this.Name = name;
        }
        public Project(int ProjectId)
        {
            Load(ProjectId);
        }
        
        #region Non Existing Project
        /// <summary>
        /// Create new Project
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            //create Project in the database
            DBAccess conn = new DBAccess("Project_Create");
            conn.AddParameter("@name", Name);

            DataSet ds = conn.ExecuteReader();
            ID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (ID == 0) { return false; } else { return true; }
        }

        public void RedirectEdit(Page page)
        {
            page.Response.Redirect("/Project_Edit.aspx?id=" + this.ID.ToString(), false);
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            DBAccess conn = new DBAccess("Project_Update");
            conn.AddParameter("@projectID", id);
            
            conn.AddParameter("@Name", Name);
            conn.AddParameter("@Summary", Summary);
            conn.AddParameter("@Description", Description);
            conn.AddParameter("@Deliverables", Deliverables);            
            conn.AddParameter("@Status", Status);
            conn.AddParameter("@UseOfFunds", UseOfFunds);
            conn.AddParameter("@RisksAndChallenges", RisksAndChallenges);
            conn.AddParameter("@FundingAim", FundingAim);
            conn.AddParameter("@BusinessModel", BusinessModel);
            conn.AddParameter("@Industry", Industry);
            conn.AddParameter("@BusinessStage", BusinessStage);
            conn.AddParameter("@CountryIncorporated", CountryIncorporated);
            conn.AddParameter("@InvestmentAmountRequiredUSD", InvestmentAmountRequiredUSD);
            conn.AddParameter("@InvestmentAmountMinimumUSD", InvestmentAmountMinimumUSD);
            conn.AddParameter("@InvestmentAmountRaisedUSD", InvestmentAmountRaisedUSD);

            conn.ExecuteNonQuery();

            return true;
        }

        public bool Delete()
        {
            DBAccess conn = new DBAccess("Project_Delete");
            conn.AddParameter("@projectID", id);
            conn.ExecuteNonQuery();

            return true;
        }


        public bool Load()
        {
            return Load(id);
        }

        /// <summary>
        /// Load Project
        /// </summary>
        /// <returns></returns>
        public bool Load(int objectId)
        {
            DBAccess conn = new DBAccess("Project_Get");
            conn.AddParameter("@projectID", objectId);

            //load goal details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                Name = dr["name"].ToString();
                Description = dr["Description"].ToString();
                Summary = dr["Summary"].ToString();
                Deliverables = dr["Deliverables"].ToString();
                Status = dr["Status"].ToString();
                UseOfFunds = dr["UseOfFunds"].ToString();
                RisksAndChallenges = dr["RisksAndChallenges"].ToString();
                FundingAim = dr["FundingAim"].ToString();
                BusinessModel = dr["BusinessModel"].ToString();
                Industry = dr["Industry"].ToString();
                BusinessStage = dr["BusinessStage"].ToString();
                UserID_Founder = Data.validInt(dr["UserID"].ToString());
                CountryIncorporated = dr["CountryIncorporated"].ToString();
                InvestmentAmountRequiredUSD = Data.validInt(dr["InvestmentAmountRequiredUSD"].ToString());
                InvestmentAmountMinimumUSD = Data.validInt(dr["InvestmentAmountMinimumUSD"].ToString());
                InvestmentAmountRaisedUSD = Data.validInt(dr["InvestmentAmountRaisedUSD"].ToString());
            }

            ID = objectId;
            return true;
        }

        #endregion

        /// <summary>
        /// Get a list of the projects related to a user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetProjects(int userID)
        {
            DBAccess conn = new DBAccess("project_GetProjectsForUser");
            conn.AddParameter("@userID", userID);
            return conn.ExecuteReader();
        }

        public static DataSet GetProjects()
        {
            return GetProjects(new List<string> { "Any" }, new List < string > { "Any" }, new List< int > { 0 }, 0, 99, "Any", 0, 100000000);
        }
        public static DataSet GetProjects(List<string> BusinessStages, List<string> Industries, List<int> StartUpExperience, int AgeFrom, int AgeTo, string Country, int InvestmentAmountRequiredUSDFrom, int InvestmentAmountRequiredUSDTo)
        {
            var tableBusinessStage = new DataTable();
            tableBusinessStage.Columns.Add("Item", typeof(string));
            foreach (string item in BusinessStages)
            {
                tableBusinessStage.Rows.Add(item);
            }

            var tableIndustry = new DataTable();
            tableIndustry.Columns.Add("Item", typeof(string));
            foreach (string item in Industries)
            {
                tableIndustry.Rows.Add(item);
            }

            var tableStartUpExperience = new DataTable();
            tableStartUpExperience.Columns.Add("Item", typeof(int));
            foreach (int item in StartUpExperience)
            {
                tableStartUpExperience.Rows.Add(item);
            }

            DBAccess conn = new DBAccess("project_GetProjects");
            conn.AddParameter("@BusinessStage", tableBusinessStage, "dbo.StringList");
            conn.AddParameter("@Industry", tableIndustry, "dbo.StringList");
            conn.AddParameter("@StartUpExperience", tableStartUpExperience, "dbo.IntList");
            conn.AddParameter("@AgeFrom", AgeFrom);
            conn.AddParameter("@AgeTo", AgeTo);
            conn.AddParameter("@Country", Country);
            conn.AddParameter("@InvestmentAmountRequiredUSDFrom", InvestmentAmountRequiredUSDFrom);
            conn.AddParameter("@InvestmentAmountRequiredUSDTo", InvestmentAmountRequiredUSDTo);
            return conn.ExecuteReader();
        }

    }
}