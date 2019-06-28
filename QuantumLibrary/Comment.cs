using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace QuantumLibrary
{
    public class Comment
    {
        public int commentMaxLength = 50000;

        public static int objectType_File = 1;
        public static int objectType_User = 2;
        public static int objectType_Thread = 3; //user to user messages
        public static int objectType_Project = 4;
        public static int objectType_ForumThread = 5;

        /// <summary>
        /// Fields
        /// </summary>
        public int id = 0, objectID = 0, userID = 0, objectType = 0;
        public string comment = "", ipAddress = "", url = "", imageData = "";
        public DateTime createdDate, deletedDate;

        public Comment()
        {}

        public Comment(int commentID)
        {
            id = commentID;
            Get(commentID);
        }

        public bool Get(int commentID)
        {
            DBAccess conn = new DBAccess("comment_Get");
            conn.AddParameter("@commentId", commentID);

            //load goal details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;

            foreach (DataRowView dr in dv)
            {
                objectID = Data.validInt(dr["objectID"].ToString());
                userID = Data.validInt(dr["userID"].ToString());
                comment = dr["comment"].ToString();
                objectType = Data.validInt(dr["objectType"].ToString());
                ipAddress = dr["ipAddress"].ToString();
            }

            return true;
        }

        public DataTable GetThread(int commentID, bool reduced)
        {
            DBAccess conn = new DBAccess("comment_GetThread");
            conn.AddParameter("@commentId", commentID);
            conn.AddParameter("@reduced", reduced);
            return ((DataSet)conn.ExecuteReader()).Tables[0];
        }

        public static DataTable GetParentComments(int tagId)
        {
            DBAccess conn = new DBAccess("comment_GetParentComments");
            conn.AddParameter("@tagID", tagId);
            return ((DataSet)conn.ExecuteReader()).Tables[0];
        }

        public bool Vote(bool voteUp, int commentID, int userID)
        {
            DBAccess conn = new DBAccess("comment_Vote");
            conn.AddParameter("@voteUp", voteUp);
            conn.AddParameter("@commentID", commentID);
            conn.AddParameter("@userID", userID);

            //load goal details into class
            conn.ExecuteNonQuery();

            return true;
        }

        /// <summary>
        /// Create new comment
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            //reduce comment to commentMaxLength (500chars)
            if (comment.Length > commentMaxLength)
            {
                comment = comment.Substring(0, commentMaxLength);
            }

            //break long words
            //comment = Data.breakLongWords(Data.nlToBr(comment));

            //remove excessive newlines
            comment = comment.Replace("<br /><br /><br />", "<br /><br />").Replace("<br /><br /><br />", "<br />").Replace("<br /><br /><br />", "<br />");

            //remove newlines from end
            while (comment.EndsWith("<br />"))
            {
                comment = comment.Substring(0, comment.Length - 6);
            }

            //uploading image
            if (true)
            {
                //Image image = new Image(imageData);
            }

            //int id = int.Newint();
            DBAccess conn = new DBAccess("comment_Create");
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@userID", userID);
            conn.AddParameter("@comment", comment);
            conn.AddParameter("@objectType", objectType);
            conn.AddParameter("@ipAddress", ipAddress);
            
            DataSet ds = conn.ExecuteReader();

            id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (id == 0) { return false; } else { return true; }
        }

        public bool Update()
        {
            //reduce comment to commentMaxLength (500chars)
            if (comment.Length > commentMaxLength)
            {
                comment = comment.Substring(0, commentMaxLength);
            }

            //break long words
            //comment = Data.breakLongWords(Data.nlToBr(comment));

            //remove excessive newlines
            comment = comment.Replace("<br /><br /><br />", "<br /><br />").Replace("<br /><br /><br />", "<br />").Replace("<br /><br /><br />", "<br />");

            //remove newlines from end
            while (comment.EndsWith("<br />"))
            {
                comment = comment.Substring(0, comment.Length - 6);
            }

            //uploading image
            if (true)
            {
                //Image image = new Image(imageData);
            }

            //int id = int.Newint();
            DBAccess conn = new DBAccess("comment_Update");
            conn.AddParameter("@ID", id);
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@userID", userID);
            conn.AddParameter("@comment", comment);
            conn.AddParameter("@objectType", objectType);
            conn.AddParameter("@ipAddress", ipAddress);
            if (deletedDate != Data.defaultDateTime()) { conn.AddParameter("@deletedDate", deletedDate); }

            object objUserID = conn.ExecuteScalar();
            return true;
        }

        public static bool Report(int commentID)
        {
            //int id = int.Newint();
            DBAccess conn = new DBAccess("comment_Report");
            conn.AddParameter("@ID", commentID);

            conn.ExecuteNonQuery();

            return true;
        }


        /// <summary>
        /// Returns comments posted for a file
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public static DataSet Get_ForObject(int objectID, int objectType)
        {
            DBAccess conn = new DBAccess("Comment_Get_ForObject");
            conn.AddParameter("@objectID", objectID);
            conn.AddParameter("@objectType", objectType);
            return conn.ExecuteReader();
        }

        public static DataSet Get_ForObject_FromCache(int objectID, int objectType, System.Web.UI.Page page)
        {
            DataSet ds;
            string cacheName = "comment.Get_ForObject" + objectID.ToString() + "ot" + objectType.ToString();

            //DISABLE CACHING
            //check if it exists in the cache 
            if (page.Cache[cacheName] == null || true)
            {
                //if it doesnt, get comments and store in cache
                ds = Get_ForObject(objectID, objectType);
                page.Cache.Insert(cacheName, ds, null, DateTime.Now.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration);
                return ds;
            }

            //return from cache
            return (DataSet)page.Cache[cacheName];
        }

        public static void Delete_FromCache(int objectID, int objectType, System.Web.UI.Page page)
        {
            string cacheName = "comment.Get_ForObject" + objectID.ToString() + "ot" + objectType.ToString();

            //check if it exists in the cache
            if (page.Cache[cacheName] != null)
            {
                page.Cache.Remove(cacheName);
            }
        }

        /// <summary>
        /// Returns files / recent comments of files to display in chan
        /// </summary>
        /// <returns></returns>
        public static DataSet Get_ForChan()
        {
            DBAccess conn = new DBAccess("Comment_Get_ForChan");
            return conn.ExecuteReader();
        }

        public static string DisplayUsername(object value)
        {
            if (value.ToString() == "")
            {
                return "Anon";
            }
            else
            {
                return "<a href='/users/" + value.ToString() + "'>" + value.ToString() + "</a>";
            }
        }




        public static bool CreateCommentFromPage()
        {
            return true;
        }
    }
}
