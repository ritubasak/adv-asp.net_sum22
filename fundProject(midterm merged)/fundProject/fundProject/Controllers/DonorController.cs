using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace fundProject.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor

        FundEntities dbObj = new FundEntities();
        public ActionResult Donor(users2 obj)
        {
            
                return View(obj);
          
        }
        [HttpPost]
        public ActionResult AddDonor(users2 model)
        {
            if (ModelState.IsValid)
            {
                users2 obj = new users2();
                obj.dnId = model.dnId;
                obj.dnName = model.dnName;
                obj.dnUserName = model.dnUserName;
                obj.dnEmail = model.dnEmail;
                obj.dnGender = model.dnGender;
                obj.dnPassword = model.dnPassword;

                if(model.dnId==0)
                {
                    dbObj.users2.Add(obj);
                    dbObj.SaveChanges();

                }

                else
                {
                    dbObj.Entry(obj).State = System.Data.EntityState.Modified;
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
            
            var res = dbObj.users2.ToList();

            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.users2.Where(x => x.dnId == id).First();
            dbObj.users2.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.users2.ToList();
            return View("DonorList", list);
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(users2 s)
        {
            if(ModelState.IsValid == true)
            {
                var dt = dbObj.users2.Where(model => model.dnUserName == s.dnUserName && model.dnPassword== s.dnPassword).FirstOrDefault();
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
            users2 d = dbObj.users2.Find(Id);
            return View(d);
        }


    }
}