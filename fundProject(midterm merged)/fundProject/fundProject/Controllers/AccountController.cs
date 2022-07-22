using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace fundProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(users1 u1)
        {
            using (FundEntities db = new FundEntities())
            {
               var result = db.users1.Where(x => x.uUserName == u1.uUserName && x.uPassword == u1.uPassword);
                
                if(result.Count()!= 0)
                {
                    
                    Session["uUserName"] = u1.uUserName;
                   
                     
                    return RedirectToAction("Index", "LoginHome");
                }
                else
                {
                    TempData["msg"] = "Incorrect User Name or Password";
                }

            }

            return View();
        }


        public ActionResult Logout()
        {

            Session.Clear();

            return RedirectToAction("Login", "Account");
            
        }

    }
}