using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for ProjectUser
    /// </summary>
    public class ProjectUser
    {
        private int ID = 0;
        private int ProjectID = 0;
        private int UserID = 0;
        private int ProjectUserTypeID = 0;
        private int InvestmentAmountUSD = 0;
        private int ProjectRoleID = 0;
        private decimal Equity = 0;

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
        /// <param name="ProjectUser"></param>
        /// <param name="pass"></param>
        public ProjectUser(int ProjectUserTypeID, int ProjectID, int UserID)
        {
            this.ProjectUserTypeID = ProjectUserTypeID;
            this.ProjectID = ProjectID;
            this.UserID = UserID;
        }
        public ProjectUser(int ProjectUserId)
        {
            Load(ProjectUserId);
        }
        
        #region Non Existing ProjectUser
        /// <summary>
        /// Create new ProjectUser
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            //create ProjectUser in the database
            DBAccess conn = new DBAccess("ProjectUser_Create");
            conn.AddParameter("@ProjectUserTypeID", ProjectUserTypeID);
            conn.AddParameter("@ProjectID", ProjectID);
            conn.AddParameter("@UserID", UserID);

            DataSet ds = conn.ExecuteReader();
            ID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (ID == 0) { return false; } else { return true; }
        }

        public void RedirectEdit(Page page)
        {
            page.Response.Redirect("/ProjectUser_Edit.aspx?id=" + this.ID.ToString(), false);
        }

        /// <summary>
        /// Update ProjectUser
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            DBAccess conn = new DBAccess("ProjectUser_Update");
            conn.AddParameter("@ID", id);
            conn.AddParameter("@ProjectID", ProjectID);
            conn.AddParameter("@UserID", UserID);
            conn.AddParameter("@ProjectUserTypeID", ProjectUserTypeID);
            conn.AddParameter("@InvestmentAmountUSD", InvestmentAmountUSD);
            conn.AddParameter("@ProjectRoleID", ProjectRoleID);
            conn.AddParameter("@Equity", Equity);
            conn.ExecuteNonQuery();

            return true;
        }


        public bool Load()
        {
            return Load(id);
        }

        /// <summary>
        /// Load ProjectUser
        /// </summary>
        /// <returns></returns>
        public bool Load(int objectId)
        {
            DBAccess conn = new DBAccess("ProjectUser_Get");
            conn.AddParameter("@ID", objectId);

            //load goal details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                ProjectID = Data.validInt(dr["ProjectID"].ToString());
                UserID = Data.validInt(dr["UserID"].ToString());
                ProjectUserTypeID = Data.validInt(dr["ProjectUserTypeID"].ToString());
                InvestmentAmountUSD = Data.validInt(dr["InvestmentAmountUSD"].ToString());
                ProjectRoleID = Data.validInt(dr["ProjectRoleID"].ToString());
                Equity = Data.validInt(dr["Equity"].ToString());
            }

            ID = objectId;
            return true;
        }

        #endregion

    }
}