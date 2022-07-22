using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        FundEntities db = new FundEntities();
        // GET: Login
        public ActionResult AdminLogin()
        {
            return View("~/Views/AdminLogin/AdminLogin.cshtml");
        }
        [HttpPost]
        public ActionResult AdminLogin(admin s, bool FlatFile)
        {

            if (ModelState.IsValid == true)
            {



                var credentials = db.admins.Where(model => model.aEmail == s.aEmail && model.aPassword == s.aPassword).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return View();
                }
                else
                {

                    if (FlatFile == true)
                    {


                        HttpCookie cookie1 = new HttpCookie("aEmail", s.aEmail.ToString());
                        cookie1.Expires = DateTime.Now.AddSeconds(60);
                        HttpContext.Response.Cookies.Add(cookie1);
                        HttpCookie cookie2 = new HttpCookie("aPassword", s.aPassword.ToString());
                        cookie2.Expires = DateTime.Now.AddSeconds(60);
                        HttpContext.Response.Cookies.Add(cookie2);


                    }


                    Session["aEmail"] = s.aEmail;
                    Session["aId"] = credentials.aId;
                    Session["aName"] = credentials.aName;






                    TempData["loginSuccess"] = "Login Success";
                    //Response.Redirect("..AdminFolder/Admin/Home.cshtml");
                   return RedirectToAction("Home", "Admin");




                }
            }
            return View("~/Views/AdminLogin/AdminLogin.cshtml");

        }

        public ActionResult AdminLogout()
        {
            Session.Abandon();
            return RedirectToAction("AdminLogin", "AdminLogin");

        }
    }
}