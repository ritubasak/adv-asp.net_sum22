using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers.employee
{
    public class EHomeController : Controller
    {
        // GET: EHome
        public ActionResult Index()
        {
          
            try
            {
                if (Session["username"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
               
            }
            catch
            {
                return RedirectToAction("Index", "Login");
                //return RedirectToAction("Leave", "Leave");

            }

           

                return View("~/Views/employee/EHome/Index.cshtml");
        }
        
        
    }
}
            //if (Session["username"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            //return View();
        