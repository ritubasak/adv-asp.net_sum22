using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers.Admin
{
    public class AcceptRequestController : Controller
    {
        FundEntities db = new FundEntities();
        // GET: Request   <a href="~/Views/AdminFolder/AcceptRequest/Index.cshtml">~/Views/AdminFolder/AcceptRequest/Index.cshtml</a>
        public ActionResult Index()
        {
            var data = db.raisers.ToList();
            return View("~/Views/AdminFolder/AcceptRequest/Index.cshtml",data);

        }

        //Edit   <a href="~/Views/AdminFolder/AcceptRequest/Edit.cshtml">~/Views/AdminFolder/AcceptRequest/Edit.cshtml</a>

        public ActionResult Edit(int Id)
        {


            var data = (from st in db.raisers where st.raiserId == Id select st).First();
            return View("~/Views/AdminFolder/AcceptRequest/Edit.cshtml",data);

        }

        [HttpPost]
        public ActionResult Edit(raiser c)
        {
            if (ModelState.IsValid)
            {

                var entity = (from st in db.raisers where st.raiserId == c.raiserId select st).First();

                db.Entry(entity).CurrentValues.SetValues(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminFolder/AcceptRequest/Edit.cshtml");


        }


    }
}