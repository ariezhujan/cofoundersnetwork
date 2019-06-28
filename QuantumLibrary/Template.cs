using System;
using System.Collections.Generic;
using System.Text;
using QuantumLibrary;
using System.Configuration;

namespace QuantumLibrary
{
    public class Template
    {
        //universan constants
        public const string Template_User_Welcome = "userWelcome.html";
        public const string Template_User_Password_Reset = "userPasswordReset.html";
        public const string Template_New_Message = "newMessage.html";
        public const string Template_New_Report = "newReport.html";
        public const string Template_Default = "default.html";
        public const string templatesDirectory = "templates";

        public string templateText = "";
        public Template(string templateName)
        {
            //get template from file
            templateText = Data.ReadFromFile(TemplatesFolder() + "\\" + templateName);

            //set siteDomain in the template for all links
            InsertValue("siteDomain", ConfigurationSettings.AppSettings["siteDomain"]);
        }

        public void InsertValue(string fieldName, string passedValue)
        {
            templateText = templateText.Replace("{" + fieldName + "}", passedValue); 
        }

        public string GetTemplateText()
        {
            return templateText;
        }

        public static string TemplatesFolder()
        {
            return ConfigurationSettings.AppSettings["rootDirectoryPhysicalPath"] + templatesDirectory + "\\";
        }
    }
}
