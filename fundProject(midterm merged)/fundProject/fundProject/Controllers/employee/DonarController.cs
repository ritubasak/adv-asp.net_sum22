using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using fundProject.Models;


namespace fundProject.Controllers.employee
{
    public class DonarController : Controller
    {

        // GET: Donar
        FundEntities dbObj = new FundEntities();

        public ActionResult Donar(Models.users2 obj)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (obj != null)
                return View("~/Views/employee/Donar/Donar.cshtml",obj);
            else
                return View("~/Views/employee/Donar/Donar.cshtml");
            //return View();
        }


        [HttpPost]
        public ActionResult AddDonar(Models.users2 model)
        {
            //if (Session["username"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            users2 obj = new users2();
           

            if (ModelState.IsValid)
            {
                obj.dnId = model.dnId;
                obj.dnName = model.dnName;
                obj.dnUserName = model.dnUserName;
                obj.dnEmail = model.dnEmail;
                obj.dnGender = model.dnGender;
                obj.dnPassword = model.dnPassword;
                ViewBag.Message = "Added Successfully";
                if (model.dnId == 0)
                {
                    dbObj.users2.Add(obj);
                    dbObj.SaveChanges();
                }



                else
                {
                   // dbObj.Entry(obj).State = System.Data.EntityState.Modified;
                    dbObj.Entry(obj).State = System.Data.EntityState.Modified;
                    dbObj.SaveChanges();
                }
                ModelState.Clear();
            }
                return View( "~/Views/employee/Donar/Donar.cshtml");
            
        }

        public ActionResult DonarList()
        {
            if (Session["username"] ==null)
            {
                return RedirectToAction("Index", "Login");
            }
            var res = dbObj.users2.ToList();
            return View("~/Views/employee/Donar/DonarList.cshtml",res);
        }



        public ActionResult Delete(int dnId)
        {
            var res = dbObj.users2.Where(x => x.dnId == dnId).First();
            dbObj.users2.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.users2.ToList();

            //return View("DonarList", list);
            return View("~/Views/employee/Donar/DonarList.cshtml",list);
        }
    }
}