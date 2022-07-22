using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        FundEntities db = new FundEntities();
        // GET: AdminHome
        public ActionResult CountHome()
        {
            
            var co = db.raisers.Select(raiserId => raiserId);
            int countOfRows = co.Count();
            Session["totalRequest"] = countOfRows;
            return View("~/Views/AdminFolder/Admin/Home.cshtml");
        }
    }
}