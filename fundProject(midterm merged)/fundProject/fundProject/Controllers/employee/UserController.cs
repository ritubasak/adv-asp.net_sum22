
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundProject.Models;

namespace fundProject.Controllers.employee
{
    public class UserController : Controller
    {
        // GET: User
        FundEntities db = new FundEntities();
        public ActionResult UserProfile()
        {

          

            int userId = Convert.ToInt32(Session["eId"]);


            //if (userId == 0)
            //{
            //    return View(db.employees.Find(userId));
            //}
            //return View();

            //return View(db.employees.Find(userId));

            if (userId == 0)
            {
                return RedirectToAction("Index", "Login");
            }

            return View("~/Views/employee/User/UserProfile.cshtml", db.employees.Find(userId));
        }
    }
}