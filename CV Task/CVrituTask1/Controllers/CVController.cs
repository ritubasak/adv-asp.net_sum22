using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVrituTask1.Controllers
{
    public class CVController : Controller
    {
        // GET: CV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult aboutme()
        {
            return View();
        }
        
    }
}