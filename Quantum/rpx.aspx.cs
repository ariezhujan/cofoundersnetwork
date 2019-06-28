using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using megaswfLibrary;
using System.Xml;
using System.Xml.XPath;

public partial class rpx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Event.SaveEvent("rpx.aspx called. request raw: " + Request.Params.ToString(), Event.Type_System);

            //# 1) Extract the token parameter from the POST data.
            string token = "";
            if (Request["token"] != null)
            {
                token = Request["token"].ToString();
            }


            //# 2) Use the token to make the auth_info API call:
            Rpx rpx_login = new Rpx("b4701a9ede5aeb63eb353849dc170dc94a0dc3a8", "https://megaswf.rpxnow.com");
            XmlElement xml = rpx_login.AuthInfo(token);
            //Event.SaveEvent("rpx xml: " + xml.InnerText, Event.Type_System);


            //# 3) Parse the response and extract the identifier. Here's a sample JSON response:
            //and email
            string identifier = GetValueFromXML(xml, "identifier");
            string email = GetValueFromXML(xml, "email");
            string verifiedEmail = GetValueFromXML(xml, "verifiedEmail");
            string preferredUsername = GetValueFromXML(xml, "preferredUsername");
            string displayName = GetValueFromXML(xml, "displayName");
            string password = Data.CreateRandomString(6); //create random password

            //check that identifier exists
            if (identifier == "")
            {
                //throw error
                throw new Exception("rpx.aspx identifier is null");
            }

            //check if an account exists
            int userID = GoalUser.GetUserIDFromExternalIdentifier(identifier);
            GoalUser user;
            if (userID != 0)
            {
                //get user
                user = new GoalUser(userID);
            }
            else
            {
                //Event.SaveEvent("data found in xml: " + identifier + "-" + email + "-" + verifiedEmail + "-" + preferredUsername + "-" + displayName + "-" + password, Event.Type_System);

                //get email
                if (verifiedEmail != "")
                {
                    email = verifiedEmail;
                }

                //get username
                string username = "";
                if (preferredUsername != "")
                {
                    username = preferredUsername;
                }
                else if (displayName != "")
                {
                    username = displayName.Replace(" ", "");
                }
                else
                {
                    username = Data.CreateRandomString(6);
                }

                //check if the username is available
                int count = 0;
                while (!GoalUser.UsernameAvailable(username))
                {
                    username = username + "1";

                    //check that the loop doesnt go for too long
                    count++;
                    if (count > 10)
                    {
                        throw new Exception("rpx.aspx while (!GoalUser.UsernameAvailable(username)) took too long. username: " + username + " identifier: " + identifier);
                    }
                }

                //create account
                user = new GoalUser(username, password);
                user.Create();
                user.email = email;
                user.name = displayName;
                user.externalIdentifier = identifier;
                user.Update();

                //send welcome email
                if (user.email != "")
                {
                    user.SendWelcomeEmail();
                }
            }

            //login and redirect to start page
            GoalUser.Login(user.username, user.password, Page, true);
        }
        catch(Exception ex)
        {
            megaswfLibrary.SystemError.Record(ex);
            Response.Redirect("/Register");
        }
    }

    protected string GetValueFromXML(XmlElement xml, string fieldName)
    {
        try
        {
            return ((XmlNode)xml.SelectSingleNode("//" + fieldName)).InnerText.Trim();
        }
        catch (Exception ex)
        {
            Event.SaveEvent("rpx.aspx GetValueFromXML field: " + fieldName + " error: " + ex.Message, Event.Type_Error);
        }
        return "";
    }

}
