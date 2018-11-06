using AddressbookApp.BO;
using AddressbookApp.Models;
using AddressbookApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AddressbookApp.Controllers
{
    /// <summary>
    /// This controller is used for validating login user details and performs logout.
    /// </summary>
    /// <remarks>
    /// Date Created: 4th Nov 2016
    /// Edited By: Phani (4-11-2016 )
    /// </remarks>
    public class LoginController : Controller
    {
        #region Initialization
        UserDetailsBO objUserDetailBO = new UserDetailsBO();
        #endregion

        #region Public Methods

        /// <summary>
        /// This method is used for rendering LogOn view
        /// GET: Login 
        /// </summary>
        /// <remarks>
        /// Date Created: 4th Nov 2016
        /// Edited By: Phani (4-11-2016 )
        /// </remarks>
        /// <param name="returnUrl">contains return url</param>
        /// <returns>view</returns>       
        public ActionResult LogOn(string returnUrl)
        {
            //ViewBag.returnUrl = returnUrl;
            // return View();
            Helper.CurrentUserRole = "Admin";
            string adminDetails = "0" + "^" + "Admin" + "^" + "Admin";
            Helper.UserData = adminDetails;
            FormsAuthentication.SetAuthCookie(adminDetails, true);
            return RedirectToAction("AdminLogin");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOn(string txtUserName, string txtPassword, string chkRememberMe, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (chkRememberMe == null)
                    chkRememberMe = "false";
                else
                    chkRememberMe = "true";

                if (txtUserName.Trim() == "admin" && txtPassword.Trim()=="admin")
                {
                    Helper.CurrentUserRole = "Admin";
                    string adminDetails = "0" + "^" + "Admin" + "^" + "Admin";
                    Helper.UserData = adminDetails;
                    FormsAuthentication.SetAuthCookie(adminDetails, Convert.ToBoolean(chkRememberMe));
                    return RedirectToAction("AdminLogin");
                }
                else
                {
                    Userdetail userdetail = objUserDetailBO.AuthenticateUser(txtUserName, txtPassword);
                    if (userdetail != null)
                    {
                        //Helper.CurrentUserID = userdetail.PKUserId;
                        string UserData = string.Empty;
                        UserData = userdetail.PKUserId + "^" + userdetail.FirstName + "^" + "User";
                        Helper.UserData = UserData;
                        FormsAuthentication.SetAuthCookie(UserData, Convert.ToBoolean(chkRememberMe));
                        return RedirectToAction("UserLogin");
                    }
                    else
                    {
                      ViewBag.message= "Invalid User Name or Password";
                        return View();
                    }
                }
            }
          return View();
        }
        /// <summary>
        /// This method is used for expiring auth cookie if user is authenticated which is created when user logins.
        /// redirects to logOn Action method
        /// </summary>
        /// <remarks>
        /// Date Created: 4th Nov 2016
        /// Edited By: Phani (4-11-2016 )
        /// </remarks>
        /// <returns></returns>
        //[Authorize]
        public ActionResult LogOff()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("LogOn");
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        #endregion
    }
}