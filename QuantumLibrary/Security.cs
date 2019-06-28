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
    /// Summary description for Security
    /// </summary>
    public class Security
    {
        public Security()
        {
        }

        /// <summary>
        /// If the current user is of the user type passed, returns true
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool access(int[] userTypes, Page page, bool redirectIfNoAccess)
        {
            bool returnValue = false;

            int currentUserType = Data.validInt(Data.getFromSession(page, "userType"));
            foreach (int userType in userTypes)
            {
                if (userType == currentUserType)
                {
                    returnValue = true;
                    break;
                }
            }

            //if the user is not of one of the type passed, redirect the user
            //only redirect if redirectIfNoAccess is true
            if (!returnValue && redirectIfNoAccess)
            {
                page.Response.Redirect(Default.Root + "goals");
            }

            //return if the user has access
            return returnValue;
        }


        //    Public Function SimpleEncrypt(ByVal TheText As String) As String
        //Dim tempChar As String = Nothing
        //Dim i As Integer = 0
        //For i = 1 To TheText.Length
        //If ToInt32(TheText.Chars(i - 1)) < 128 Then
        //tempChar = System.Convert.ToString(ToInt32(TheText.Chars(i - 1)) + 100)
        //ElseIf ToInt32(TheText.Chars(i - 1)) > 128 Then
        //tempChar = System.Convert.ToString(ToInt32(TheText.Chars(i - 1)) - 100)
        //End If
        //TheText = TheText.Remove(i - 1, 1).Insert(i - 1, (CChar(ChrW(tempChar))).ToString())
        //Next i
        //Return TheText
        //End Function 


    }
}