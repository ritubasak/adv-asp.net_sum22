using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation

        FundEntities dbObj = new FundEntities();

        public ActionResult Donation()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login","Donor");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddDonation(tbl_donation model)
        {
            if (ModelState.IsValid)
            {

                tbl_donation obj = new tbl_donation();
                obj.UserName = model.UserName;
                obj.Ammount = model.Ammount;

                dbObj.tbl_donation.Add(obj);
                dbObj.SaveChanges();

            }

            ModelState.Clear();

            return View("Donation");
        }

        public ActionResult DonationList()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Donor");
            }

            var store = dbObj.tbl_donation.ToList();

            return View(store);
        }

    }
}