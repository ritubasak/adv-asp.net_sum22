using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;


namespace fundProject.Controllers.Admin
{
    public class employeeController : Controller
    {
        FundEntities db = new FundEntities();
        // GET: employee
        public ActionResult Index()
        {
            var data = db.employees.ToList();
            return View("~/Views/AdminFolder/employee/Index.cshtml",data);

        }

        //Create Employee <a href="~/Views/AdminFolder/employee/Create.cshtml">~/Views/AdminFolder/employee/Create.cshtml</a>

        public ActionResult Create()
        {
            return View("~/Views/AdminFolder/employee/Create.cshtml");
        }
        [HttpPost]
        public ActionResult Create(Models.employee c)
        {

            if (ModelState.IsValid)
            {

                db.employees.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View("~/Views/AdminFolder/employee/Create.cshtml",c);


        }

        //Details <a href="~/Views/AdminFolder/employee/Details.cshtml">~/Views/AdminFolder/employee/Details.cshtml</a>
        public ActionResult Details(int Id)
        {
            
            
            var data = (from st in db.employees where st.eId == Id select st).First();
            
            return View("~/Views/AdminFolder/employee/Details.cshtml",data);
        }

        //Delete 

        public ActionResult Delete(int Id)
        {
            
            var data = (from st in db.employees where st.eId == Id select st).First();
            db.employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit <a href="~/Views/AdminFolder/employee/Edit.cshtml">~/Views/AdminFolder/employee/Edit.cshtml</a>
        public ActionResult Edit(int Id)
        {

            
            var data = (from st in db.employees where st.eId == Id select st).First();
            return View("~/Views/AdminFolder/employee/Edit.cshtml", data);

        }

        [HttpPost]
        public ActionResult Edit(Models.employee c)
        {
            if (ModelState.IsValid)
            {
                
                var entity = (from st in db.employees where st.eId == c.eId select st).First();

                //var isRoleExist = (from role in db.Customer_Roles where role.Id == c.RoleId select role).Any();

                //if (!isRoleExist)
                //{
                //    TempData["RoleMsg"] = "Role Doesnot Exist";
                //    return View();
                //}


                db.Entry(entity).CurrentValues.SetValues(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminFolder/employee/Edit.cshtml");


        }


        //print 

        public ActionResult PrintEmps()
        {
            return new ActionAsPdf("PrintEmp");
        }

        public ActionResult PrintEmp()
        {
            var data = db.employees.ToList();
            return View(data); ;
        }







    }
}