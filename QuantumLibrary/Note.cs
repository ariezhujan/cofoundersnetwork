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
    public class Note
    {
        #region Fields
        public string title, note;
        public DateTime createdDate;
        public Guid parentNoteId, goalId, userId;
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
        public Note()
        {
            ID = Guid.Empty;
            parentNoteId = Guid.Empty;
            goalId = Guid.Empty;
        }

        /// <summary>
        /// Create new note
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            Guid id = Guid.NewGuid();
            DBAccess conn = new DBAccess("note_Create");
            conn.AddParameter("@noteID", id);
            conn.AddParameter("@userID", userId);
            if (parentNoteId != Guid.Empty)
            {
                conn.AddParameter("@parentNoteId", parentNoteId);
            }
            conn.AddParameter("@goalId", goalId);

            conn.ExecuteScalar();

            ID = id;
            return true;
        }

        /// <summary>
        /// Delete note
        /// </summary>
        /// <returns></returns>
        public static bool Delete(Guid objectId)
        {
            DBAccess conn = new DBAccess("note_Delete");
            conn.AddParameter("@noteID", objectId);
            conn.ExecuteScalar();

            return true;
        }



        /// <summary>
        /// Update goal
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            DBAccess conn = new DBAccess("note_Update");
            conn.AddParameter("@noteID", id);

            conn.AddParameter("@title", title);
            conn.AddParameter("@note", note);

            conn.ExecuteScalar();

            ID = id;
            return true;
        }



        /// <summary>
        /// Load goal
        /// </summary>
        /// <returns></returns>
        public bool Load(Guid objectId)
        {
            DBAccess conn = new DBAccess("note_Get");
            conn.AddParameter("@noteID", objectId);

            //load goal details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                title = dr["title"].ToString();
                note = dr["note"].ToString();
                createdDate = Data.validDateTime(dr["createdDate"].ToString());
                parentNoteId = Data.validGuid((dr["parentNoteID"].ToString()));
                userId = Data.validGuid((dr["userId"].ToString()));
                goalId = Data.validGuid((dr["goalId"].ToString()));
            }

            ID = objectId;
            return true;
        }
        #endregion


        #region Forms
        /// <summary>
        /// Return all the notes for a goal
        /// </summary>
        /// <param name="userId"></param>
        public static DataSet GetAllForGoal(Guid goalId)
        {
            DBAccess conn = new DBAccess("note_Get");
            conn.AddParameter("@goalId", goalId);
            return conn.ExecuteReader();
        }
        /// <summary>
        /// Return all the notes for a note
        /// </summary>
        /// <param name="userId"></param>
        public static DataSet GetAllForNote(Guid parentNoteId)
        {
            DBAccess conn = new DBAccess("note_Get");
            conn.AddParameter("@parentNoteId", parentNoteId);
            return conn.ExecuteReader();
        }
        #endregion
    }
}