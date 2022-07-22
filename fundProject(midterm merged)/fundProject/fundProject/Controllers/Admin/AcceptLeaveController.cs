using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers.Admin
{
    public class AcceptLeaveController : Controller
    {
        FundEntities db = new FundEntities();
        // GET: Request

        //<a href="~/Views/AdminFolder/AcceptLeave/Edit.cshtml">~/Views/AdminFolder/AcceptLeave/Edit.cshtml</a>
        //<a href = "~/Views/AdminFolder/AcceptLeave/Index.cshtml" > ~/ Views / AdminFolder / AcceptLeave / Index.cshtml </ a >
        public ActionResult Index()
        {
            var data = db.leaves.ToList();
            return View("~/Views/AdminFolder/AcceptLeave/Index.cshtml",data);

        }

        //Edit 

        public ActionResult Edit(int Id)
        {


            var data = (from st in db.leaves where st.leaveId == Id select st).FirstOrDefault();
            return View("~/Views/AdminFolder/AcceptLeave/Edit.cshtml",data);

        }

        [HttpPost]
        public ActionResult Edit(leave c)
        {
            if (ModelState.IsValid)
            {

                var entity = (from st in db.leaves where st.leaveId == c.leaveId select st).First();

                db.Entry(entity).CurrentValues.SetValues(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminFolder/AcceptLeave/Edit.cshtml");


        }





    }
}