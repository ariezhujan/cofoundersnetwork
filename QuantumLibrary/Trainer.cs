using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace QuantumLibrary
{

    /// <summary>
    /// Summary description for Note
    /// </summary>
    public class Trainer
    {
        #region Fields
        public string name, introductoryText, contactInformation, helpInformation, advertisement;
        public DateTime createdDate;
        private Guid ID;

        public Guid id
        {
            get
            {
                return ID;
            }
        }
        #endregion



        #region Modify

        /// <summary>
        /// Constructior
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public Trainer()
        {
            ID = Guid.Empty;
        }

        /// <summary>
        /// Create new trainer
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            Guid id = Guid.NewGuid();
            DBAccess conn = new DBAccess("trainer_Create");
            conn.AddParameter("@trainerID", id);

            conn.ExecuteScalar();

            ID = id;
            return true;
        }

        /// <summary>
        /// Delete trainer
        /// </summary>
        /// <returns></returns>
        public static bool Delete(Guid objectId)
        {
            DBAccess conn = new DBAccess("trainer_Delete");
            conn.AddParameter("@trainerID", objectId);
            conn.ExecuteScalar();

            return true;
        }



        /// <summary>
        /// Update trainer
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            DBAccess conn = new DBAccess("trainer_Update");
            conn.AddParameter("@trainerID", id);

            conn.AddParameter("@name", name);
            conn.AddParameter("@introductoryText", introductoryText);
            conn.AddParameter("@contactInformation", contactInformation);
            conn.AddParameter("@helpInformation", helpInformation);
            conn.AddParameter("@advertisement", advertisement);

            conn.ExecuteScalar();

            ID = id;
            return true;
        }



        /// <summary>
        /// Load trainer
        /// </summary>
        /// <returns></returns>
        public bool Load(Guid objectId)
        {
            DBAccess conn = new DBAccess("trainer_Get");
            conn.AddParameter("@trainerID", objectId);

            //load goal details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                name = dr["name"].ToString();
                introductoryText = dr["introductoryText"].ToString();
                createdDate = Data.validDateTime(dr["createdDate"].ToString());
                contactInformation = dr["contactInformation"].ToString();
                helpInformation = dr["helpInformation"].ToString();
                advertisement = dr["advertisement"].ToString();
            }

            ID = objectId;
            return true;
        }
        #endregion


        #region Forms
        /// <summary>
        /// Return all the trainers
        /// </summary>
        /// <param name="userId"></param>
        public static DataSet GetAll()
        {
            DBAccess conn = new DBAccess("trainer_Get");
            return conn.ExecuteReader();
        }
        #endregion
    }
}
