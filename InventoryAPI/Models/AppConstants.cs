using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InventoryAPI.Models
{
    public class AppConstants
    {
        static string strUID = "", strPWD = "";
        static string strDBName = "", strServerName = "";
        public static string getConnectionString()
        {
            strServerName = ConfigurationManager.AppSettings["Server"];
            strDBName = ConfigurationManager.AppSettings["DBName"];
            strUID = ConfigurationManager.AppSettings["UID"];
            strPWD = ConfigurationManager.AppSettings["PWD"];
            return "Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";Persist Security Info=True;User ID=" + strUID + ";Password=" + strPWD;
        }
    }
}