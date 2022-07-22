using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using fundProject.Models;

namespace fundProject.Controllers.employee
{
    public class LoginController : Controller
    {
        FundEntities db = new FundEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View("~/Views/employee/Login/Index.cshtml");
        }

         [HttpPost]
         public ActionResult Index (Models.employee s)
         {
             if (ModelState.IsValid == true)
             {
                 Models.employee ep = new Models.employee();

        var credentials = db.employees.Where(model => model.eUserName == s.eUserName && model.ePassword == s.ePassword).FirstOrDefault();
        if (credentials == null)
        {
           ViewBag.ErrorMessage = "Login Failed";
                    //return View();
                    return View("~/Views/employee/Login/Index.cshtml");
                }
        else 
                {
                   Session["username"] = s.eUserName;
                    Session["password"] = s.ePassword;
                    Session["eId"] = s.eId;
                    
                    //Session["username"] = new username() { usrNme = name, usrFirstName = dataset.usrFirst, usrLastName = dataset.usrLast };

                    return RedirectToAction("Index","EHome");
                    //return RedirectToAction("~/Views/employee/EHome/Index.cshtml");
                }
                //else if (credentials != null)
                //{
                //    Session["username"] = s.eUserName;
                   

                //    return RedirectToAction("Donar", "Donar");
                //}

            }
            //return RedirectToAction("Index", "EHome");

            return View("~/Views/employee/Login/Index.cshtml");

        }



        public ActionResult Edit()
        {
            //if (Session["username"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            var val = Session["username"];
            var val1 = Session["Password"];
            var data = (from st in db.employees where st.eUserName == val && st.ePassword == val1 select st).FirstOrDefault();
           // return View(data);
            return View("~/Views/employee/Login/Edit.cshtml",data);
            // return View();

        }


        [HttpPost]
        public ActionResult Edit(Models.employee c)
        {
            if (ModelState.IsValid)
            {

                var entity = (from st in db.employees where st.eUserName == c.eUserName && st.ePassword == c.ePassword select st).First();
                db.Entry(entity).CurrentValues.SetValues(c);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "EHome");
                //return RedirectToAction("~/Views/employee/EHome/Index.cshtml");
            }
            return View("~/Views/employee/Login/Edit.cshtml");


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

        //public ActionResult Edit1()
        //{
        //    var employees = db.employees.Include(e => e.eName);
        //    return View(employees.ToList());
        //}

        //// GET: Employee/Details/5  
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}


        //public ActionResult Edit()
        //{
        //    string username = User.Identity.Name;

        //    // Fetch the userprofile
        //    Models.employee user = db.employees.FirstOrDefault(u => u.eUserName.Equals(username));

        //    // Construct the viewmodel
        //    Models.employee model = new Models.employee();
        //   model. = user.FirstName;
        //    model.LastName = user.LastName;
        //    model.Email = user.Email;

        //    return View(model);
        //}

        //public ActionResult Edit()
        //{

        //    //var credentials = db.employees.Where(model => model.eUserName == s.eUserName && model.ePassword == s.ePassword).FirstOrDefault();
        //    var res = db.employees.ToList();
        //    return View(res);
        //}



        //public ActionResult EEdit(Models.employee obj)
        //{

        //    if (obj != null)
        //        return View(obj);
        //    else
        //        return View();
        //}

        //public ActionResult AddEdit()
        //{
        //    string username = User.Identity.Name;

        //    // Fetch the userprofile
        //    Models.employee user = db.employees.FirstOrDefault(u => u.eUserName.Equals(username));
        //   // UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.Equals(username));

        //    // Construct the viewmodel
        //    Models.employee model = new Models.employee();
        //    //model.FirstName = user.FirstName;
        //    //model.LastName = user.LastName;
        //    //model.Email = user.Email;

        //    model.eId = user.eId;
        //    model.eName = user.eName;
        //    model.eUserName = user.eUserName;
        //    model.eEmail = user.eEmail;
        //    model.eGender = user.eGender;
        //    model.ePassword = user.ePassword;

        //    return View(model);
        //}


        //[HttpPost]
        //public ActionResult SEdit(Models.employee userprofile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string username = User.Identity.Name;
        //        // Get the userprofile
        //        Models.employee user = db.employees.FirstOrDefault(u => u.eUserName.Equals(username));

        //        // Update fields
        //        user.eId = userprofile.eId;
        //        user.eName = userprofile.eName;
        //        user.eUserName = userprofile.eUserName;
        //        user.eEmail = userprofile.eEmail;
        //        user.eGender = userprofile.eGender;
        //        user.ePassword = userprofile.ePassword;


        //        db.Entry(user).State = EntityState.Modified;

        //        db.SaveChanges();

        //        return RedirectToAction("Index", "EHome"); // or whatever
        //    }

        //    return View(userprofile);
        //}

        //[HttpPost]
        //public ActionResult AddEdit(Models.employee model)
        //{
        //    Models.employee obj = new Models.employee();
        //    //{ 
        //    //if (ModelState.IsValid)
        //    //{
        //    obj.eId = model.eId;
        //    obj.eName = model.eName;
        //    obj.eUserName = model.eUserName;
        //    obj.eEmail = model.eEmail;
        //    obj.eGender = model.eGender;
        //    obj.ePassword = model.ePassword;
        //    //if (model.eId == 0)
        //    //{
        //    db.employees.Add(obj);
        //    db.SaveChanges();
        //    //}


        //    //else
        //    //{
        //    //    db.Entry(obj).State = System.Data.EntityState.Modified;
        //    //    db.SaveChanges();
        //    //}
        //    ModelState.Clear();

        //    return View("EEdit");
        //}





        // GET: Home/Create
        //public ActionResult Edit()
        //{
        //    return View();
        //}

        //public ActionResult Edit(int eId)
        //{
        //    //fundEntities db = new fundEntities();
        //    //Models.employee e = new Models.employee();

        //    var std = db.employees.Where (x => x.eId == eId).FirstOrDefault();

        //    return View(std);
        //}

        //[HttpPost]
        //public ActionResult Edit(Models.employee std)
        //{
        //    //update student in DB using EntityFramework in real-life application

        //    //update list by removing old student and adding updated student for demo purpose
        //    var student = db.employees.Where(s => s.eId == std.eId).FirstOrDefault();
        //    db.employees.Remove(student);
        //    db.employees.Add(std);

        //    return RedirectToAction("Index");
        //}










        // POST: Home/Create
        //[HttpPost]
        //public ActionResult Edit(Models.employee collection)
        //{
        //    try
        //    {
        //        //Method 1: Using Component Name  

        //        /*ViewData["Name"] = collection["Name"];
        //        ViewData["City"] = collection["City"];
        //        ViewData["Address"] = collection["Address"];*/

        //        //Method 2: Using Component Index Position

        //        Models.employee model = new Models.employee();
        //        //    model.eId = user.eId;
        //        //    model.eName = user.eName;
        //        //    model.eGender = user.eGender;
        //        //    model.eEmail = user.eEmail;
        //        //    model.eUserName = user.eUserName;
        //        //    model.ePassword = user.ePassword;
        //        ViewData["eId"] = collection.eId;
        //        ViewData["eName"] = collection.eName;
        //        ViewData["eGender"] = collection.eGender;
        //        ViewData["eEmail"] = collection.eEmail;
        //        ViewData["eUserName"] = collection.eUserName;
        //        ViewData["ePassword"] = collection.ePassword;

        //        return View("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}







        ////new
        //public ActionResult Edit()
        //{
        //    string username = User.Identity.Name;

        //    // Fetch the userprofile

        //    var user = db.employees.FirstOrDefault(u => u.eUserName.Equals(username));

        //    // Construct the viewmodel
        //    Models.employee model = new Models.employee();
        //    model.eId = user.eId;
        //    model.eName = user.eName;
        //    model.eGender = user.eGender;
        //    model.eEmail = user.eEmail;
        //    model.eUserName = user.eUserName;
        //    model.ePassword = user.ePassword;

        //    return View(model);


        //}

        //[HttpPost]



        //public ActionResult Edit(Models.employee s)
        //{
        //    Models.employee ep = new Models.employee();
        //    if (ModelState.IsValid == true)
        //    {
        //        ep.eId = s.eId;
        //        ep.eName = s.eName;
        //        ep.eGender = s.eGender;
        //        ep.eEmail = s.eEmail;
        //        ep.eUserName = s.eUserName;
        //        ep.ePassword = s.ePassword;

        //        db.Entry(ep).State = System.Data.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Login");
        //    }

        //    return View();
        //}


        //[HttpPost]
        //public ActionResult emp (Models.employee s)
        //{
        //   Models.employee ep = new Models.employee();
        //    if (ModelState.IsValid == true)
        //    {
        //        ep.eId= s.eId;
        //        ep.eName= s.eName;
        //        ep.eGender= s.eGender;
        //        ep.eEmail = s.eEmail;
        //        ep.eUserName= s.eUserName;
        //        ep.ePassword= s.ePassword;

        //        db.Entry(ep).State = System.Data.EntityState.Modified;
        //        db.SaveChanges();
        //    }

        //    return View();
        //}














        public ActionResult Logout()
        {
            Session.Abandon();
            //return RedirectToAction("~/Views/employee/Login/Index.cshtml");
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Reset()
        {
            ModelState.Clear();
            //return RedirectToAction("~/Views/employee/Login/Index.cshtml");
            return RedirectToAction("Index", "Login");
        }
    }
}