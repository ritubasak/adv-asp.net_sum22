using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundProject.Models;

namespace fundProject.Controllers.employee
{
    public class RaiserController : Controller
    {
        // GET: Raiser
        FundEntities dbObj = new FundEntities();
        public ActionResult Raiser(users1 obj)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (obj != null)
                return View("~/Views/employee/Raiser/Raiser.cshtml", obj);
            //return View(obj);
            else
                return View("~/Views/employee/Raiser/Raiser.cshtml");
        }



        [HttpPost]
        public ActionResult AddRaiser(users1 model)
        {
            users1 obj = new users1();
            if (ModelState.IsValid)
            {
                obj.uId = model.uId;
                obj.uName = model.uName;
                obj.uUserName = model.uUserName;
                obj.uEmail = model.uEmail;
                obj.uGender = model.uGender;
                obj.uPassword = model.uPassword;
                ViewBag.Message = "Added Successfully";
                if (model.uId == 0)
                {
                    dbObj.users1.Add(obj);
                    dbObj.SaveChanges();
                }


                else
                {
                    //  dbObj.Entry(obj).State = System.Data.EntityState.Modified;
                    dbObj.Entry(obj).State = System.Data.EntityState.Modified;
                    dbObj.SaveChanges();
                }
                ModelState.Clear();
            }
            return View("~/Views/employee/Raiser/Raiser.cshtml");

        }

        public ActionResult RaiserList()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var res = dbObj.users1.ToList();
            return View("~/Views/employee/Raiser/RaiserList.cshtml",res);
        }



        public ActionResult Delete(int uId)
        {
            var res = dbObj.users1.Where(x => x.uId == uId).First();
            dbObj.users1.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.users1.ToList();

            return View("~/Views/employee/Raiser/RaiserList.cshtml", list);
        }
    }


}