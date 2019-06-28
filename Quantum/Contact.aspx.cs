using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuantumLibrary;

namespace Quantum
{
    public partial class Contact
        : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptcha.Validate(EncodedResponse) == "true" ? true : false);

            //if (!IsCaptchaValid)
            //{
            //    litMessage.Text = "Please complete the page validation reCaptcha.";
            //    return;
            //}

            //send email
            //todo
            if (txtEmail.Text.Trim() == "" || txtMessage.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                litMessage.Text = "Please fill in the form fields.";
            }
            else
            {
                Communication.SendEmail("eli@fairon.biz", "CoFoundersNetwork Contact Form - " + ddlReason.Value, txtMessage.Text.Trim(), Application);
                litMessage.Text = "Message sent. We will get back to you ASAP.";
                txtEmail.Enabled = false;
                txtMessage.Enabled = false;
                txtName.Enabled = false;
                btnSend.Enabled = false;
            }
        }
    }
}