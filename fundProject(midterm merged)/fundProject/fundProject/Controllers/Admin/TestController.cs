using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers.Admin
{
    public class TestController : Controller
    {
        // GET: Test
        //public ActionResult Index()
        //{
        //    return View("~/Views/AN/Test/Index.cshtml");
        //    //return View("~/Views/YourArea/YourController/YourView.aspx");


        //    //< a href = "~/Views/AN/Test/Index.cshtml" > ~/Views/AN/Test/Index.cshtml </ a >
        //}
        

        public ActionResult page1() {
            return View("~/Views/AN/Test/page1.cshtml");
        }

        public ActionResult Index()
        {
            FundEntities db = new FundEntities();
            var data = db.admins.ToList();
            return View("~/Views/AN/Test/Index.cshtml",data);

        }
    }   
}
