using System;
using System.Data;
using System.Web;
using System.Web.UI;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for ObjectListValue
    /// </summary>
    public class ObjectListValue
    {
        public static int ObjectType_userID = 1;
        public static int ObjectType_projectID = 2;

        private int ID = 0;

        public int objectID = 0;
        public int objectType = 0;
        public string valueType = "";
        public int listValueID1 = 0;
        public int list1 = 0;
        public int listValueID2 = 0;
        public int list2 = 0;
        public string stringValue1 = "";
        public string stringValue2 = "";
        public string stringValue3 = "";
        public int intValue1 = 0;
        public decimal intValue2 = 0;
        public decimal decValue1 = 0;
        public DateTime dateValue1;


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
        /// <param name="ObjectListValue"></param>
        /// <param name="pass"></param>
        public ObjectListValue(int objectID, int objectType, string valueType)
        {
            this.objectID = objectID;
            this.objectType = objectType;
            this.valueType = valueType;
        }
        public ObjectListValue(int ObjectListValueID)
        {
            Load(ObjectListValueID);
        }
        
        #region Non Existing ObjectListValue
        /// <summary>
        /// Create new ObjectListValue
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            //create ObjectListValue in the database
            DBAccess conn = new DBAccess("ObjectListValue_Create");
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@objectType", objectType);
            conn.AddParameter("@valueType", valueType);

            DataSet ds = conn.ExecuteReader();
            ID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (ID == 0) { return false; } else { return true; }
        }


        /// <summary>
        /// Update ObjectListValue
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            DBAccess conn = new DBAccess("ObjectListValue_Update");
            conn.AddParameter("@ID", id);
            
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@objectType", objectType);
            conn.AddParameter("@valueType", valueType);
            conn.AddParameter("@listValueID1", listValueID1);
            conn.AddParameter("@list1", list1);
            conn.AddParameter("@listValueID2", listValueID2);
            conn.AddParameter("@list2", list2);
            conn.AddParameter("@stringValue1", stringValue1);
            conn.AddParameter("@stringValue2", stringValue2);
            conn.AddParameter("@stringValue3", stringValue3);
            conn.AddParameter("@intValue1", intValue1);
            conn.AddParameter("@intValue2", intValue2);
            conn.AddParameter("@decValue1", decValue1);
            if (dateValue1.ToString("yyyy") != "0001") { conn.AddParameter("@dateValue1", dateValue1); }

            conn.ExecuteNonQuery();

            return true;
        }

        public bool Delete()
        {
            DBAccess conn = new DBAccess("ObjectListValue_Delete");
            conn.AddParameter("@ID", id);
            conn.ExecuteNonQuery();

            return true;
        }


        public bool Load()
        {
            return Load(id);
        }

        /// <summary>
        /// Load ObjectListValue
        /// </summary>
        /// <returns></returns>
        public bool Load(int objectId)
        {
            DBAccess conn = new DBAccess("ObjectListValue_Get");
            conn.AddParameter("@ID", objectId);

            //load details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                objectID = Data.validInt(dr["objectID"].ToString());
                objectType = Data.validInt(dr["objectType"].ToString());
                valueType = dr["valueType"].ToString();
                listValueID1 = Data.validInt(dr["listValueID1"].ToString());
                list1 = Data.validInt(dr["list1"].ToString());
                listValueID2 = Data.validInt(dr["listValueID2"].ToString());
                list2 = Data.validInt(dr["list2"].ToString());
                stringValue1 = dr["stringValue1"].ToString();
                stringValue2 = dr["stringValue2"].ToString();
                stringValue3 = dr["stringValue3"].ToString();
                intValue1 = Data.validInt(dr["intValue1"].ToString());
                intValue2 = Data.validInt(dr["intValue2"].ToString());
                decValue1 = Data.validInt(dr["decValue1"].ToString());
            }

            ID = objectId;
            return true;
        }

        #endregion

        /// <summary>
        /// Get a list of the ObjectListValues related to a user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetObjectListValues(int objectID, int objectType, string valueType)
        {
            DBAccess conn = new DBAccess("ObjectListValue_GetForObject");
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@objectType", objectType);
            conn.AddParameter("@valueType", valueType);

            return conn.ExecuteReader();
        }


        public static DataSet GetListValues(string list, int objectID, int objectType, bool includePreviouslyUsed)
        {
            DBAccess conn = new DBAccess("listValues_Get");
            conn.AddParameter("@list", list);
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@objectType", objectType);
            conn.AddParameter("@IncludePreviouslyUsed", includePreviouslyUsed);            
            return conn.ExecuteReader();
        }
    }
}