using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuantumLibrary;
using System.Web.UI;

namespace QuantumLibrary
{
    public class ForumThread
    {
        public string title;
        public DateTime createdDate, lastComment, deletedDate;
        public int ID, userID, userID2=0, forumID, imageID, firstCommentID;

        public ForumThread()
        { }

        public ForumThread(int forumThreadID)
        {
            ID = forumThreadID;
            Load(forumThreadID);
        }

        public void NotifyRecipient(Comment comment, System.Web.HttpApplicationState application)
        {
            //identify recipient
            GoalUser userRecipient;
            GoalUser userSender;
            if (comment.userID == userID)
            {
                userRecipient = new GoalUser(userID2);
                userSender = new GoalUser(userID);
            }
            else
            {
                userRecipient = new GoalUser(userID);
                userSender = new GoalUser(userID2);
            }

            //notify the user that they've been sent a message
            Template template = new Template(Template.Template_New_Message);
            template.InsertValue("name", userRecipient.name);
            template.InsertValue("sender", userSender.name);
            Communication.SendEmail(userRecipient.username, "Co-Founders Network - New Message from " + userSender.name, template.GetTemplateText(), application);
        }
        
        public bool Create()
        {
            //create user in the database
            DBAccess conn = new DBAccess("forum_SaveThread");
            conn.AddParameter("@forumID", forumID);
            conn.AddParameter("@title", title);
            conn.AddParameter("@userID", userID);
            if (userID2 != 0) { conn.AddParameter("@userID2", userID2); }

            DataSet ds = conn.ExecuteReader();
            ID = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            return true;
        }

        public bool Update()
        {
            //create user in the database
            DBAccess conn = new DBAccess("forum_UpdateThread");
            conn.AddParameter("@ID", ID);
            conn.AddParameter("@forumID", forumID);
            conn.AddParameter("@title", title);
            conn.AddParameter("@userID", userID);
            if (userID2 != 0) { conn.AddParameter("@userID2", userID2); }
            conn.AddParameter("@imageID", imageID);
            conn.AddParameter("@firstCommentID", firstCommentID);
            if (deletedDate != Data.defaultDateTime()) { conn.AddParameter("@deletedDate", deletedDate); }

            conn.ExecuteScalar();

            return true;
        }

        public bool Load(int objectId)
        {
            DBAccess conn = new DBAccess("forum_GetThread");
            conn.AddParameter("@ID", objectId);

            //load details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                title = dr["title"].ToString();
                createdDate = Data.validDateTime(dr["createdDate"].ToString());
                lastComment = Data.validDateTime(dr["lastComment"].ToString());
                userID = Data.validInt(dr["userID"].ToString());
                userID2 = Data.validInt(dr["userID2"].ToString());
                forumID = Data.validInt(dr["forumID"].ToString());
                imageID = Data.validInt(dr["imageID"].ToString());
                firstCommentID = Data.validInt(dr["firstCommentID"].ToString());
            }

            ID = objectId;
            return true;
        }

        /// <summary>
        /// Redirect to the messaging form and open the specific thread for viewing
        /// </summary>
        /// <param name="page"></param>
        public void RedirectToInternalChat(Page page)
        {
            page.Response.Redirect("/Messaging.aspx?forumThreadID="+this.ID.ToString(), false);
        }
    }
}
