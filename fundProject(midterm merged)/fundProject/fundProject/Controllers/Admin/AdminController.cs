using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers.Admin
{
    public class AdminController : Controller
    {
        FundEntities db = new FundEntities();
        // GET: Admin <a href="~/Views/AdminFolder/Admin/Index.cshtml">~/Views/AdminFolder/Admin/Index.cshtml</a>
        public ActionResult Index()
        {
            var data = db.admins.ToList();
            return View("~/Views/AdminFolder/Admin/Index.cshtml",data);

        }

        //Create Admin <a href="~/Views/AdminFolder/Admin/Create.cshtml">~/Views/AdminFolder/Admin/Create.cshtml</a>


        public ActionResult Create()
        {
            return View("~/Views/AdminFolder/Admin/Create.cshtml");
        }
        [HttpPost]
        public ActionResult Create(admin c)
        {

            if (ModelState.IsValid)
            {
                
                db.admins.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View("~/Views/AdminFolder/Admin/Create.cshtml",c);


        }

        //Edit

        public ActionResult Edit()
        {

            int val = (int)Session["aId"]; 
            var data = (from st in db.admins where st.aId == val select st).FirstOrDefault();
            return View("~/Views/AdminFolder/Admin/Edit.cshtml",data);

        }

        //[HttpPost]
        //public ActionResult Edit(admin c)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var entity = (from st in db.admins where st.aId == c.aId select st).First();

        //        //var isRoleExist = (from role in db.Customer_Roles where role.Id == c.RoleId select role).Any();

        //        //if (!isRoleExist)
        //        //{
        //        //    TempData["RoleMsg"] = "Role Doesnot Exist";
        //        //    return View();
        //        //}


        //        db.Entry(entity).CurrentValues.SetValues(c);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();


        //}

        [HttpPost]
        public ActionResult Edit(admin c)
        {
            if (ModelState.IsValid)
            {

                var entity = (from st in db.admins where st.aId == c.aId select st).First();
                db.Entry(entity).CurrentValues.SetValues(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminFolder/Admin/Edit.cshtml");


        }

        //View Data  <a href = "~/Views/AdminFolder/Admin/Details.cshtml" > ~/ Views / AdminFolder / Admin / Details.cshtml </ a >
        public ActionResult Details(int Id)
        {
            
            var entity = (from st in db.admins
                          where st.aId == Id
                          select st).First();
            return View("~/Views/AdminFolder/Admin/Details.cshtml",entity);
        }

        //Delete
        //[HttpPost]
        //public ActionResult Delete(int Id)
        //{

        //    var data = (from st in db.admins where st.aId == Id select st).First();
        //    db.admins.Remove(data);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}




        //Admin Home Page

        public ActionResult Home()
        {

            var co = db.raisers.Select(raiserId => raiserId);
            int countOfRows = co.Count();
            ViewData["totalRequest"] = countOfRows;


            var co1 = db.users1.Select(uId => uId);
            int countOfRows1 = co1.Count();

            var co2 = db.users1.Select(duId => duId);
            int countOfRows2 = co2.Count();

            ViewData["totalUser"] = countOfRows1+ countOfRows2;

            var co3 = db.employees.Select(eId => eId);
            int countOfRows3 = co3.Count();
            ViewData["totalEmployee"] = countOfRows3;



            return View("~/Views/AdminFolder/Admin/Home.cshtml");
        }







    }
}