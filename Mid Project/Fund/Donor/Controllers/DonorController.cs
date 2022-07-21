using Donor.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace Donor.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor

        FundEntities dbObj = new FundEntities();
        public ActionResult Donor(Tbl_Donor obj)
        {
            
                return View(obj);
          
        }
        [HttpPost]
        public ActionResult AddDonor(Tbl_Donor model)
        {
            if (ModelState.IsValid)
            {
                Tbl_Donor obj = new Tbl_Donor();
                obj.dnId = model.dnId;
                obj.dnName = model.dnName;
                obj.dnUserName = model.dnUserName;
                obj.dnEmail = model.dnEmail;
                obj.dnGender = model.dnGender;
                obj.dnPassword = model.dnPassword;

                if(model.dnId==0)
                {
                    dbObj.Tbl_Donor.Add(obj);
                    dbObj.SaveChanges();

                }

                else
                {
                    dbObj.Entry(obj).State= EntityState.Modified;
                    dbObj.SaveChanges();
                }

                
            }
            ModelState.Clear();

            return View("Donor");
        }

        public ActionResult DonorList()
        {

            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Donor");
            }
            
            var res = dbObj.Tbl_Donor.ToList();

            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.Tbl_Donor.Where(x => x.dnId == id).First();
            dbObj.Tbl_Donor.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.Tbl_Donor.ToList();
            return View("DonorList", list);
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Tbl_Donor s)
        {
            if(ModelState.IsValid == true)
            {
                var dt = dbObj.Tbl_Donor.Where(model => model.dnUserName == s.dnUserName && model.dnPassword== s.dnPassword).FirstOrDefault();
                if(dt == null)
                {
                    ViewBag.ErrorMessage = "Login Failed!";
                    return View();
                }
                else
                {
                    Session["username"] = s.dnUserName;
                    return RedirectToAction("Donation", "Donation");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login","Donor");
        }

        public ActionResult Details(int Id = 0)
        {
            Tbl_Donor d = dbObj.Tbl_Donor.Find(Id);
            return View(d);
        }


    }
}