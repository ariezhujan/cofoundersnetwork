using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using QuantumLibrary;

namespace QuantumLibrary
{
    public class Forum
    {
        public static int ForumID_InternalChat = 1;
        public static int ForumID_Blog = 2;
        public static int ForumID_Hustlers = 3;
        public static DataSet GetThreads(int forumID, int PageNumber, int PageSize, int userID)
        {
            DBAccess conn = new DBAccess("forum_Threads");
            conn.AddParameter("@PageNumber", PageNumber);
            conn.AddParameter("@PageSize", PageSize);
            conn.AddParameter("@ForumID", forumID);

            //get threads that the user has permission to view
            if(userID!=0)
            {
                conn.AddParameter("@UserID", userID);
            }

            return conn.ExecuteReader();
        }    
    }
}
