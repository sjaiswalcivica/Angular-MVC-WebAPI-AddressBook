using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressbookApp.Utility
{
    public class Helper
    {
        private static string _UserData;
        public static void ShowAlert(System.Web.UI.Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), DateTime.Now.ToString(), "alert(\"" + message + "\");", true);
        }

        public static int CurrentUserID
        {
            get
            {
                return Convert.ToInt32(UserData.Split('^')[0]);
            }
            set { }
        }
        public static string CurrentUserRole
        {
            get
            {
                return UserData.Split('^')[2];
            }
            set { }
        }
        public static string CurrentUserName
        {
            get
            {
                return UserData.Split('^')[1];
            }
            set { }
        }

        public static string UserData
        {
            get
            {
                return _UserData;
            }
            set
            {
                _UserData = value;
            }
        }
    }
}