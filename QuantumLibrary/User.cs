using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Collections.Generic;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    public class GoalUser
    {
        public static int usertype_User_Regular = 1;
        public static int usertype_User_Pro = 2;
        public static int usertype_User_Admin = 3;

        private int ID = 0;
        public string username;
        private int loginCount;
        public DateTime lastLogin, createdDate, deletedDate;

        public string _image = "", externalIdentifier = "", password = "", name = "", about = "", country = "", country2 = "", website = "", embedWhiteList = "", businessStage = "", industry = "", skills = "", position = "";
        public int trainerId = 0, age = 0, points = 0, startUpExperience = 0, amountToInvestUSD=0, hourstoCollaborate=0;
        public int userType = usertype_User_Regular, proType = 0;
        public bool acceptEmail = true, acceptEmailMarketing = true, emailAddressConfirmed = false, lookingToInvest = false, lookingToCollaborate = false;
        public int acceptEmailMarketingFrequency = 7; //emails every 7 days

        //public DateTime messagesLastViewed;
        //public int messagesUnread = 0;

        public string image
        {
            get
            {
                if (_image != "")
                {
                    return _image;
                }
                else
                {
                    return "user_no_image.jpg";
                }
            }
            set
            {
                _image = value;
            }
        }

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

        //token used for user authentication and cookies
        public string Token()
        { return StringCipher.Encrypt(ID.ToString(), "userID"); }
        public int IDFromToken(string value)
        {
            string valueFromToken = StringCipher.Decrypt(ID.ToString(), "userID");
            int returnValue = 0;
            int.TryParse(valueFromToken, out returnValue);
            return returnValue;
        }


        /// <summary>
        /// Constructior
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public GoalUser(string user, string pass)
        {
            username = user;
            password = pass;
        }
        public GoalUser(int userId)
        {
            Load(userId);
        }

        public GoalUser(string username)
        {
            //get userid based on username
            int userID = 0;
            DBAccess conn = new DBAccess("user_GetUserIDFromUsername");
            conn.AddParameter("@username", username);

            //load goal details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                userID = Data.validInt(dr["id"].ToString());
                Load(userID);
            }
        }

        public static int GetUserIDFromExternalIdentifier(string externalIdentifier)
        {
            //get userid based on external identifier (facebook, twitter etc from janrain)
            int userID = 0;
            DBAccess conn = new DBAccess("user_GetUserIDFromExternalIdentifier");
            conn.AddParameter("@externalIdentifier", externalIdentifier);

            //return userID if found
            DataTable dt = ((DataSet)conn.ExecuteReader()).Tables[0];
            if(dt.Rows.Count>0)
            {
                userID = Data.validInt(dt.Rows[0]["id"].ToString());
            }
            return userID;
        }

        #region Non Existing User
        /// <summary>
        /// Create new user
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            //create user in the database
            DBAccess conn = new DBAccess("user_Create");
            conn.AddParameter("@username", username);
            conn.AddParameter("@password", password);

            DataSet ds = conn.ExecuteReader();
           
            ID = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (ID == 0) { return false; } else { return true; }
        }

        public void SendWelcomeEmail(HttpServerUtility server, System.Web.HttpApplicationState application)
        {
            //get template
            Template template = new Template(Template.Template_User_Welcome);
            template.InsertValue("username", this.username);
            template.InsertValue("name", this.name);
            template.InsertValue("a", server.UrlEncode(StringCipher.Encrypt(this.username))); //used in the link to confirm the email address

            //send email
            Communication.SendEmail(this.username, "Welcome to Co-Founders Network", template.GetTemplateText(), application);
        }

        public void SendEmail(string message, string subject, System.Web.HttpApplicationState application)
        {
            if (this.acceptEmail)
            {
                //get default template
                Template template = new Template(Template.Template_Default);
                template.InsertValue("message", message);
                template.InsertValue("name", this.name);

                //send email
                Communication.SendEmail(this.username, "CoFoundersNetwork - " + subject, template.GetTemplateText(), application);
            }
        }

        public static void SendNewsletter(string message, string subject, System.Web.HttpApplicationState application)
        {
            //get list of all emails
            string email;
            DataSet ds = GetUsersForNewsletter();
            if (ds.Tables[0].Rows.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                while (count >= 0)
                {
                    email = "";
                    email = ds.Tables[0].Rows[count]["email"].ToString();
                    try
                    {
                        //for each send email
                        Communication.SendEmail(email, subject, message.Replace("{email}", email), application);
                    }
                    catch (Exception ex)
                    {
                        Event.SaveEvent("User.SendNewsletter Error: " + ex.Message, Event.Type_Error);
                    }

                    count--;
                }

            }
        }


        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            DBAccess conn = new DBAccess("user_Update");
            conn.AddParameter("@ID", id);

            conn.AddParameter("@username", username);
            conn.AddParameter("@password", password);
            conn.AddParameter("@userType", userType);
            conn.AddParameter("@proType", proType);
            conn.AddParameter("@acceptEmail", acceptEmail);
            conn.AddParameter("@acceptEmailMarketing", acceptEmail);
            conn.AddParameter("@acceptEmailMarketingFrequency", acceptEmail);
            conn.AddParameter("@emailAddressConfirmed", emailAddressConfirmed);
            conn.AddParameter("@name", name);
            conn.AddParameter("@about", about);
            conn.AddParameter("@country", country);
            conn.AddParameter("@country2", country2);
            conn.AddParameter("@website", website);
            conn.AddParameter("@age", age);
            conn.AddParameter("@embedWhiteList", embedWhiteList);
            conn.AddParameter("@externalIdentifier", externalIdentifier);
            conn.AddParameter("@startupExperience", startUpExperience);
            conn.AddParameter("@businessStage", businessStage);
            conn.AddParameter("@industry", industry);
            conn.AddParameter("@image", image);
            conn.AddParameter("@lookingToInvest", lookingToInvest);
            conn.AddParameter("@amountToInvestUSD", amountToInvestUSD);
            conn.AddParameter("@lookingToCollaborate", lookingToCollaborate);
            conn.AddParameter("@hourstoCollaborate", hourstoCollaborate);
            conn.AddParameter("@skills", skills);
            conn.AddParameter("@position", position);
            //conn.AddParameter("@messagesUnread", messagesUnread);
            //conn.AddParameter("@messagesLastViewed", messagesLastViewed);
            if (deletedDate != Data.defaultDateTime())
            {
                conn.AddParameter("@deletedDate", deletedDate);
            }

            try
            {
                conn.ExecuteNonQuery();
            } catch
             (Exception ex)
            { }
            return true;
        }


        public bool Load()
        {
            return Load(id);
        }

        public static GoalUser Load_FromCache(int objectId, System.Web.UI.Page page)
        {
            GoalUser goalUser;
            string cacheID = "goalUserObject" + objectId.ToString();

            //check if it exists in the cache
            if (page.Cache[cacheID] == null)
            {
                //if it doesnt, get and store in cache    
                goalUser = new GoalUser(objectId);
                page.Cache.Insert(cacheID, goalUser, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                return goalUser;
            }

            //return from cache
            return (GoalUser)page.Cache[cacheID];
        }

        public static void Delete_FromCache(int objectId, System.Web.UI.Page page)
        {
            //check if it exists in the cache
            if (page.Cache["goalUserObject" + objectId.ToString()] != null)
            {
                page.Cache.Remove("goalUserObject" + objectId.ToString());
            }
        }

        /// <summary>
        /// Load user
        /// </summary>
        /// <returns></returns>
        public bool Load(int objectId)
        {
            DBAccess conn = new DBAccess("user_Get");
            conn.AddParameter("@ID", objectId);

            //load goal details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                username = dr["username"].ToString();
                password = dr["password"].ToString();
                userType = Data.validInt(dr["userType"].ToString());
                proType = Data.validInt(dr["proType"].ToString());
                loginCount = Data.validInt(dr["loginCount"].ToString());
                createdDate = Data.validDateTime(dr["createdDate"].ToString());
                deletedDate = Data.validDateTime(dr["deletedDate"].ToString());
                lastLogin = Data.validDateTime(dr["lastLogin"].ToString());
                acceptEmail = Data.validBool(dr["acceptEmail"].ToString());
                acceptEmailMarketing = Data.validBool(dr["acceptEmailMarketing"].ToString());
                acceptEmailMarketingFrequency = Data.validInt(dr["acceptEmailMarketingFrequency"].ToString());
                emailAddressConfirmed = Data.validBool(dr["emailAddressConfirmed"].ToString());
                name = dr["name"].ToString();
                about = dr["about"].ToString();
                country = dr["country"].ToString();
                country2 = dr["country2"].ToString();
                website = dr["website"].ToString();
                age = Data.validInt(dr["age"].ToString());
                embedWhiteList = dr["embedWhiteList"].ToString();
                externalIdentifier = dr["externalIdentifier"].ToString();
                image = dr["image"].ToString();
                points = Data.validInt(dr["points"].ToString());
                industry = dr["industry"].ToString();
                businessStage = dr["businessStage"].ToString();
                startUpExperience = Data.validInt(dr["startUpExperience"].ToString());
                lookingToInvest = Data.validBool(dr["lookingToInvest"].ToString());
                amountToInvestUSD = Data.validInt(dr["amountToInvestUSD"].ToString());
                lookingToCollaborate = Data.validBool(dr["lookingToCollaborate"].ToString());
                hourstoCollaborate = Data.validInt(dr["hourstoCollaborate"].ToString());
                skills = dr["skills"].ToString();
                position = dr["position"].ToString();
                //messagesUnread = Data.validInt(dr["messagesUnread"].ToString());
                //messagesLastViewed = Data.validDateTime(dr["messagesLastViewed"].ToString());
            }

            ID = objectId;
            return true;
        }

        public static bool GetPassword(string emailUsername, ref string password, ref string email)
        {
            DBAccess conn = new DBAccess("user_GetPassword");
            conn.AddParameter("@value", emailUsername);

            //return password
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                password = dr["password"].ToString();
                email = dr["email"].ToString();
                return true;
            }

            return false;
        }





        /// <summary>
        /// Returns true if the username is available
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool UsernameAvailable(string username)
        {
            DBAccess conn = new DBAccess("user_UsernameAvailable");
            conn.AddParameter("@username", username);
            object returnValue;
            returnValue = conn.ExecuteScalar();

            if (returnValue == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void UnsubscribeEmail(string email)
        {
            email = email.Trim();

            DBAccess conn = new DBAccess("user_UnsubscribeEmail");
            conn.AddParameter("@email", email);
            object returnValue;
            returnValue = conn.ExecuteScalar();
        }
        #endregion

        #region Existing User Not Logged In
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <returns></returns>
        public bool Authenticate()
        {
            try
            {
                DBAccess conn = new DBAccess("user_Authenticate");
                conn.AddParameter("@username", username);
                conn.AddParameter("@password", password);
                object objUserID = conn.ExecuteScalar();

                ID = int.Parse(objUserID.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void Login(string username, string password, Page page, bool remember)
        {
            GoalUser user = new GoalUser(username, password);

            //if user found
            if (user.Authenticate())
            {
                //load common variables into the session
                GoalUser.LoadSessionVariables(user, page, remember);

                //redirect to starting page
                GoalUser.RedirectHome(page);
            }
        }


        public static bool HasCookie(Page page)
        {
            if (GoalUser.UserLoggedIn(page))
            {
                return true;
            }

            //check if the user has a do not login cookie
            HttpCookie doNotLoginCookie = page.Request.Cookies["effortDoNotLogin"];
            if (doNotLoginCookie == null || doNotLoginCookie.Value.ToString() == "")
            {
                //check if the user has a user id cookie
                //HttpCookie myEncryptedCookie = HttpCookieEncryption.Decrypt(this.Context, "myEncryptedCookie");
                HttpCookie cookie = page.Request.Cookies["effortUserID"];
                if (cookie != null && cookie.Value.ToString() != "")
                {
                    //get userid
                    String strUserID = StringCipher.Decrypt(cookie.Value.ToString());

                    //log user in
                    GoalUser user = GoalUser.Load_FromCache(Data.validInt(strUserID), page);
                    user.Authenticate(); //record the login

                    if (user.username == null)
                    {
                        RemoveCookie(page);
                        return false;
                    }
                    LoadSessionVariables(user, page, true);

                    //cookie found and user logged in
                    return true;
                }
            }

            //user not logged in
            return false;
        }


        public static void LoadSessionVariables(GoalUser user, Page page, bool remember)
        {
            page.Session["userID"] = user.id.ToString();
            page.Session["username"] = user.username;

            user.Load();
            page.Session["userType"] = user.userType.ToString();


            //save userID to a cookie for the user
            HttpCookie cookie = new HttpCookie("effortUserID");
            if (remember)
            {
                //if remember is checked, save the userid to the users cookie 
                //TODO encryption
                cookie.Value = StringCipher.Encrypt(user.id.ToString());

                //remove do not login cookie
                HttpCookie doNotLoginCookie = new HttpCookie("effortDoNotLogin");
                doNotLoginCookie.Value = "";
                doNotLoginCookie.Expires = DateTime.Now.AddDays(-1d);
                page.Response.Cookies.Add(doNotLoginCookie);
            }
            else
            {
                cookie.Value = "";
            }
            cookie.Expires = DateTime.Now.AddYears(1);
            page.Response.Cookies.Add(cookie);
        }

        public static void RemoveCookie(Page page)
        {
            //REMOVE COOKIES
            //delete userID cookie
            HttpCookie cookie = new HttpCookie("effortUserID");
            cookie.Value = "";
            cookie.Expires = DateTime.Now.AddDays(-1d);
            page.Response.Cookies.Add(cookie);

            //delete do not login cookie
            HttpCookie doNotLoginCookie = new HttpCookie("effortDoNotLogin");
            doNotLoginCookie.Value = "";
            doNotLoginCookie.Expires = DateTime.Now.AddDays(-1d);
            page.Response.Cookies.Add(doNotLoginCookie);
        }
        #endregion

        #region Current User Logged In
        public static void RedirectHome(Page page)
        {
            page.Response.Redirect("/User_Welcome.aspx", false);
        }

        /// <summary>
        /// Returns the userId of the current user
        /// </summary>
        /// <returns></returns>
        public static int CurrentUserId(Page page)
        {
            return Data.validInt(Data.getFromSession(page, "userId"));
        }
        public static int CurrentUserType(Page page)
        {
            return Data.validInt(Data.getFromSession(page, "userType"));
        }
        public static GoalUser CurrentUser(Page page)
        {
            return new GoalUser(CurrentUserId(page));
        }

        public static bool EmailAvailable(string email)
        {
            //todo
            return true;
        }

        /// <summary>
        /// Returns true if a user is logged in
        /// </summary>
        /// <returns></returns>
        public static bool UserLoggedIn(Page page)
        {
            if (CurrentUserId(page) != 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Redirect to root if user is not logged in
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static void CheckUserLoggedIn(Page page)
        {
            if (!UserLoggedIn(page))
            {
                if (!HasCookie(page))
                {
                    page.Response.Redirect(Default.LoginPage);
                }
            }
        }


        /// <summary>
        /// Clear session and return to main page
        /// </summary>
        /// <param name="page"></param>
        public static void Logout(Page page)
        {
            try
            {
                //save do not login cookie for the user
                HttpCookie doNotLoginCookie = new HttpCookie("effortDoNotLogin");
                doNotLoginCookie.Value = "true";
                doNotLoginCookie.Expires = DateTime.Now.AddYears(1);
                page.Response.Cookies.Add(doNotLoginCookie);
            }
            catch { }

            try
            {
                //delete userID cookie
                HttpCookie cookie = new HttpCookie("effortUserID");
                cookie.Value = "";
                cookie.Expires = DateTime.Now.AddDays(-1d);
                page.Response.Cookies.Add(cookie);
            }
            catch { }


            //clear session and return to default
            page.Session.Clear();
            page.Response.Redirect(Default.Root);
        }



        #endregion

        #region Rank       
        public static DataSet GetUsersByRank()
        {
            DBAccess conn = new DBAccess("user_GetUsersByRank");
            return conn.ExecuteReader();
        }
        #endregion

        #region Manage Users
        public static DataSet GetUsersForNewsletter()
        {
            DBAccess conn = new DBAccess("user_GetUsersForNewsletter");
            return conn.ExecuteReader();
        }
        public static DataSet GetUsersUnderTrainer(int trainerId)
        {
            DBAccess conn = new DBAccess("user_GetUsersUnderTrainer");
            conn.AddParameter("@trainerId", trainerId);
            return conn.ExecuteReader();
        }


        public static DataSet GetUsers(List<string> BusinessStages, List<string> Industries, List<int> StartUpExperience, int AgeFrom, int AgeTo, string Country, List<int> Skills)
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

            var tableSkill = new DataTable();
            tableSkill.Columns.Add("Item", typeof(string));
            foreach (int item in Skills)
            {
                tableSkill.Rows.Add(item);
            }

            DBAccess conn = new DBAccess("user_GetUsers");
            conn.AddParameter("@BusinessStage", tableBusinessStage, "dbo.StringList");
            conn.AddParameter("@Industry", tableIndustry, "dbo.StringList");
            conn.AddParameter("@StartUpExperience", tableStartUpExperience, "dbo.IntList");
            conn.AddParameter("@AgeFrom", AgeFrom);
            conn.AddParameter("@AgeTo", AgeTo);
            conn.AddParameter("@Country", Country);
            conn.AddParameter("@Skill", tableSkill, "dbo.IntList");
            return conn.ExecuteReader();
        }        
        #endregion

        public static string GetUserIPAddress(System.Web.UI.Page page)
        {
            //get ip address
            string ip = page.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            // If there is no proxy, get the standard remote address
            if ((ip == null) || (ip == "") || (ip.ToLower() == "unknown"))
            {
                ip = page.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }


        #region Bandwidth
        public static DataSet Get_UserBandwidth(int year, int month)
        {
            DBAccess conn = new DBAccess("user_Get_UsersBandwidth");
            conn.AddParameter("@year", year);
            conn.AddParameter("@month", month);
            return conn.ExecuteReader();
        }

        public static DataSet Get_FilesBandwidth(int year, int month, int userID)
        {
            DBAccess conn = new DBAccess("user_Get_FilesBandwidth");
            conn.AddParameter("@year", year);
            conn.AddParameter("@month", month);
            conn.AddParameter("@userID", userID);
            return conn.ExecuteReader();
        }

        public static DataSet Get_MonthBandwidth(int userID)
        {
            DBAccess conn = new DBAccess("user_Get_MonthBandwidth");
            conn.AddParameter("@userID", userID);
            return conn.ExecuteReader();
        }

        public static string GetProTypeName(int protypeID)
        {
            DBAccess conn = new DBAccess("user_GetProTypeName");
            conn.AddParameter("@id", protypeID);

            //return
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                return dr["name"].ToString();
            }

            return "unknown protypeID";
        }
        #endregion
    }
}