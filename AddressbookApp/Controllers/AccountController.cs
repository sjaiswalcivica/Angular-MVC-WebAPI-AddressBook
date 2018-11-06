using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBookPOC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            string username = col["txtUserName"];
            string password = col["txtPassword"];
            if (username == "admin")
                return RedirectToAction("AdminLogin");
            else
                return RedirectToAction("UserLogin");
        }

        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
    }
}