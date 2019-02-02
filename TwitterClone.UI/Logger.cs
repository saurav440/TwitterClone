using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

namespace TwitterClone.UI
{
    public class Logger
    {
        public static void WriteLog(HandleErrorInfo info)
        {
            var content = "Controller: " + info.ControllerName + Environment.NewLine +
                "Action Name: " + info.ActionName + Environment.NewLine +
                "Error Message: " + info.Exception.Message + Environment.NewLine +
                "Date: " + DateTime.Now + Environment.NewLine +
                "*****************************************************";
            string logpath = ConfigurationManager.AppSettings["logPath"].ToString();

            using (StreamWriter sw = new StreamWriter(logpath,true))
            {
                sw.WriteLine(content);
            }
        }
    }
}