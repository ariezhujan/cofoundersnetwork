using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for Communication
    /// </summary>
    public class Communication
    {
        //default bulk to false
        public static void SendEmail(string to, string subject, string message, System.Web.HttpApplicationState application)
        {
            SendEmail(to, subject, message, false, application); 
        }

        public static void SendEmail(string to, string subject, string message, bool bulk, System.Web.HttpApplicationState application)
        {
            //prevent flooding
            //get last time an email was sent to this address
            string lastSentTime = "";
            if (application["emailOutTo" + to] != null)
            {
                DateTime lastSendTimeDate = Data.validDateTime(application["emailOutTo" + to].ToString());
                TimeSpan elapsed = DateTime.Now.Subtract(lastSendTimeDate);
                if (elapsed.Minutes < 5)
                {
                    return; //don't send the email
                } 
            }

            //get the from email address
            string from = ConfigurationSettings.AppSettings["email_adminAddress"].ToString();
            Event.SaveEvent("Email sent From: " + from + " To: " + to + " Subject: " + subject, Event.Type_Email);

            try
            {
                //send email
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(to));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                if (bulk)
                {
                    mail.Headers.Add("Precedence", "bulk");
                }
                SmtpClient client = new SmtpClient();


                //if email server details in the settings file
                if (ConfigurationSettings.AppSettings["email_server"] != null)
                {
                    //client.UseDefaultCredentials = false;
                    //System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(, );
                    //client.Credentials = theCredential;
                    //client.Host = 

                    client.Host = ConfigurationSettings.AppSettings["email_server"].ToString();
                    client.Credentials = new System.Net.NetworkCredential
                         (ConfigurationSettings.AppSettings["email_username"].ToString(), ConfigurationSettings.AppSettings["email_password"].ToString());
                    client.Port = 587;
                    client.EnableSsl = true;
                }
                else
                {
                    client.Host = "localhost";
                }

                client.Send(mail);


                application["emailOutTo" + to] = DateTime.Now;
            }
            catch (Exception ex)
            {
                SystemError.Record(ex);
            }
        }
    }
}