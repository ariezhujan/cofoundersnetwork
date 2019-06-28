using System;
using System.Data;
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
    /// Summary description for Event
    /// </summary>
    public class Event
    {
        public const int Type_Email = 1;
        public const int Type_SMS = 2;
        public const int Type_Purchase = 3;
        public const int Type_System = 4;
        public const int Type_Error = 5;
        public const int Type_Purchase_RawData = 6;
        public const int Type_SMS_Test = 7;
        public const int Type_Search = 8;
        public const int Type_MessageToAdmin = 9;
        public const int Type_Error_UserReport = 10;
        public const int Type_System_AutoIconCreation = 11;
        public const int Type_System_AutoIconCreation_Failed = 12;

        public static void SaveEvent(string description, int eventTypeID)
        {
            SaveEvent(description, eventTypeID, 0);
        }


        public static void SaveEvent(string description, int eventTypeID, int objectID)
        {
            DBAccess conn = new DBAccess("DS_Event_Save");

            //only pass the id if it is not empty
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@eventTypeID", eventTypeID);
            conn.AddParameter("@description", description);

            conn.ExecuteScalar();
        }

        public static DataTable GetEventstForObjectIDAndType(int eventTypeID)
        {
            return GetEventstForObjectIDAndType(eventTypeID, 0);
        }
        public static DataTable GetEventstForObjectIDAndType(int eventTypeID, int objectID)
        {
            DBAccess conn = new DBAccess("DS_Event_GetForObjectIDAndType");
            conn.AddParameter("objectID", objectID);
            conn.AddParameter("eventTypeID", eventTypeID);
            return ((DataSet)conn.ExecuteReader()).Tables[0];
        }

        public static DataTable GetTypes()
        {
            DBAccess conn = new DBAccess("DS_Event_GetTypes");
            return ((DataSet)conn.ExecuteReader()).Tables[0];
        }
    }
}