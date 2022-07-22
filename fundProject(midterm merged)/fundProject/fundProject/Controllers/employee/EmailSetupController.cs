using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundProject.Models;
using System.Net;
using System.Net.Mail;

namespace fundProject.Controllers.employee
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View("~/Views/employee/EmailSetup/Index.cshtml");
            //return View();
        }

        [HttpPost]
        public ActionResult Index(fundProject.Models.gmail model)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //mail change 
            MailMessage mm = new MailMessage("fariahossain1409@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            //another mail , 
            NetworkCredential nc = new NetworkCredential("fariahossain1409@gmail.com", "smiktrlhozksaseg");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);

            ViewBag.Message = "Mail has been sent successfully";
            //return View();
            return View("~/Views/employee/EmailSetup/Index.cshtml");
        }
    }
}