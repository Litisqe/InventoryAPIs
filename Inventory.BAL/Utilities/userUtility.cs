using System.Configuration;

namespace Inventory.BAL.Utilities
{
    public sealed class userUtility
    {
        private static userUtility instance;
        public static userUtility Instance
        {
            get
            {
                if (instance == null)
                    instance = new userUtility();
                return instance;
            }
        }
        public bool VaidateUser(string username, string password)
        {
            // Check if it is valid credential
            if (username == ConfigurationManager.AppSettings["ApiUID"].ToString() && password == ConfigurationManager.AppSettings["ApiPWD"].ToString())//CheckUserInDB(username, password))  
                return true;
            else
                return false;
        }
    }
}
