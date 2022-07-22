using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundProject.Models;

namespace fundProject.Controllers.employee
{
    public class leaveController : Controller
    {
        // GET: leave
        FundEntities dbLeave = new FundEntities();
        public ActionResult leave()
        {
            


            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View("~/Views/employee/leave/leave.cshtml");
            //return View();
        }


        //public ActionResult leave()
        //{
        //    //if (Session["username"] == null)
        //    //{
        //    //    return RedirectToAction("Index", "Login");
        //    //}

        //    var val = Session["username"];
        //    var val1 = Session["Password"];
        //    var data = (from st in dbLeave.leaves where st.eUserName == val && st.ePassword == val1 select st).FirstOrDefault();
        //    return View(data);
        //    // return View();

        //}


        //[HttpPost]
        //public ActionResult leave(Models.employee c)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var entity = (from st in dbLeave.employees where st.eUserName == c.eUserName && st.ePassword == c.ePassword select st).First();
        //        dbLeave.Entry(entity).CurrentValues.SetValues(c);
        //        dbLeave.SaveChanges();
        //        //return RedirectToAction("Index");
        //        return RedirectToAction("Index", "EHome");
        //    }
        //    return View();


        //}







        [HttpPost]
        public ActionResult AddLeave(leave model)
        {
            leave obj = new leave();
           //if (ModelState.IsValid)
            //{
            obj.leaveId = model.leaveId;
            obj.eId = model.eId;
            obj.description = model.description;
               ViewBag.Message = "Application submitted";
                //if (model.Id == 0)
                //{
                dbLeave.leaves.Add(obj);
            dbLeave.SaveChanges();
           


            //}


        //    //else
            //{
            //    dbObj.Entry(obj).State = System.Data.EntityState.Modified;
            //    dbObj.SaveChanges();
            //}
            ModelState.Clear();
                return View("~/Views/employee/leave/leave.cshtml");
        }
    }
}
