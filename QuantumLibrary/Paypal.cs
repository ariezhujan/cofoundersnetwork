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
    /// Summary description for Paypal
    /// </summary>
    public class PayPal
    {
        //need to add custom = guid user if to all the links 

        public static string Pro_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=575MW6WTVAZU4";
        public static string Pro_Month_6 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=X9ER56ABWP45N";
        public static string Pro_Month_12 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E8FWRLFGX6QH4";

        public static string Pro_L2_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JK36DFT5AJM5Y";
        public static string Pro_L3_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=YWYU9FK5X2EAQ";
        public static string Pro_E1_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=84A8W4DK3UXVA";
        public static string Pro_E2_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=X4GEKN4V92YVE";
        public static string Pro_E3_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=RWFLMPQLGP92C";
        public static string Pro_E4_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ZNFQY8DXFFS42";
        public static string Pro_E5_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=K2A8JHYVHHFMG";
        public static string Pro_E6_Month_1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3MURBJC995FKU";

        public static int Pro_L1_ID = 1;
        public static int Pro_L2_ID = 2;
        public static int Pro_L3_ID = 3;
        public static int Pro_E1_ID = 4;
        public static int Pro_E2_ID = 5;
        public static int Pro_E3_ID = 6;
        public static int Pro_E4_ID = 7;
        public static int Pro_E5_ID = 8;
        public static int Pro_E6_ID = 9;
        public static int Pro_HA1_ID = 10;
        public static int Pro_HA2_ID = 11;
        public static int Pro_HA3_ID = 12;
        public static int Pro_HA4_ID = 13;

        public static string URL(System.Web.UI.Page page, string url)
        {
            return url + "&custom=" + GoalUser.CurrentUserId(page);
        }
    }
}