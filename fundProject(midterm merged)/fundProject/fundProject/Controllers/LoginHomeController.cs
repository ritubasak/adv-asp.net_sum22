using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers
{
    public class LoginHomeController : Controller
    {
        // GET: LoginHome
        public ActionResult Index()
        {
            try
            {
                if (Session["uUserName"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }

            return View("Index");
           // return RedirectToAction("Index");


        }
    }
}