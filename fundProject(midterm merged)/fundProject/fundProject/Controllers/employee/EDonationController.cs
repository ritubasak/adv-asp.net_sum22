using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundProject.Models;
namespace fundProject.Controllers.employee
{
    public class EDonationController : Controller
    {
        FundEntities dbObj = new FundEntities();
        // GET: EDonation
        public ActionResult Index()
        {

            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var res = dbObj.tbl_donation.ToList();
            return View("~/Views/employee/EDonation/Index.cshtml",res);

        }
    }
}