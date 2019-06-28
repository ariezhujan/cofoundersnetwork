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

public partial class Paypal_Complete_Notify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //record passed POST request as error
        Event.SaveEvent("Paypal notify POST raw data - " + Request.Params.ToString() + " " + Request.Params.AllKeys.ToString(), Event.Type_Purchase_RawData);

        try
        {
            //process details from post
            string userID, item_name, item_number, txn_type, payment_gross, mc_currency;

            userID = GetRequestValue("custom");
            item_name = GetRequestValue("item_name");
            item_number = GetRequestValue("item_number");
            txn_type = GetRequestValue("txn_type");
            payment_gross = GetRequestValue("payment_gross");
            mc_currency = GetRequestValue("mc_currency");


            //get user
            GoalUser user = new GoalUser(int.Parse(userID));

            //if user not found, try userid as username
            if (user.id == 0)
            {
                user = new GoalUser(userID);
            }

            //subscription
            if (txn_type == "subscr_signup")
            {
                user.userType = GoalUser.usertype_User_Pro;
                SetProType(ref user, item_name);
                user.Update();

                //remove cache
                GoalUser.Delete_FromCache(user.id, Page);

                //record subscription
                Event.SaveEvent(item_name + " subscription setup.", Event.Type_Purchase, user.id);
            }
            else if (txn_type == "subscr_payment")
            {
                //record payment
                Event.SaveEvent(payment_gross + mc_currency + " paid for " + item_name, Event.Type_Purchase, user.id);
            }
            else if (txn_type == "subscr_cancel")
            {
                user.userType = GoalUser.usertype_User_Regular;
                user.Update();

                //remove cache
                GoalUser.Delete_FromCache(user.id, Page);

                //record cancellation
                Event.SaveEvent(item_name + " subscription cancelled.", Event.Type_Purchase, user.id);
            }
            else if (txn_type == "web_accept")
            {
                //record sms purchase
                Event.SaveEvent(item_name + " purchased for " + payment_gross + mc_currency, Event.Type_Purchase, user.id);
            }
            else
            {
                //record passed POST request as error
                Event.SaveEvent("Paypal notify POST txn_type unknown. " + "txn_type: " + txn_type + " - " + Request.Params.ToString() + " " + Request.Params.AllKeys.ToString(), Event.Type_Error);
            }
        }
        catch (Exception ex)
        {
            SystemError.Record(ex);
        }
    }

    private void SetProType(ref GoalUser user, string item_name)
    {
        if (item_name.Contains("L2"))
        {
            user.proType = PayPal.Pro_L2_ID;
        }
        else if (item_name.Contains("L3"))
        {
            user.proType = PayPal.Pro_L3_ID;
        }
        else if (item_name.Contains("E1"))
        {
            user.proType = PayPal.Pro_E1_ID;
        }
        else if (item_name.Contains("E2"))
        {
            user.proType = PayPal.Pro_E2_ID;
        }
        else if (item_name.Contains("E3"))
        {
            user.proType = PayPal.Pro_E3_ID;
        }
        else if (item_name.Contains("E4"))
        {
            user.proType = PayPal.Pro_E4_ID;
        }
        else if (item_name.Contains("E5"))
        {
            user.proType = PayPal.Pro_E5_ID;
        }
        else if (item_name.Contains("E6"))
        {
            user.proType = PayPal.Pro_E6_ID;
        }
        else if (item_name.Contains("HA1"))
        {
            user.proType = PayPal.Pro_HA1_ID;
        }
        else if (item_name.Contains("HA2"))
        {
            user.proType = PayPal.Pro_HA2_ID;
        }
        else if (item_name.Contains("HA3"))
        {
            user.proType = PayPal.Pro_HA3_ID;
        }
        else if (item_name.Contains("HA4"))
        {
            user.proType = PayPal.Pro_HA4_ID;
        }
        else
        {
            user.proType = PayPal.Pro_L1_ID; //standard $5 per month account
        }
    }

    private string GetRequestValue(string key)
    {
        try
        {
            return Request[key].ToString();
        }
        catch { }

        return "";
    }
}
