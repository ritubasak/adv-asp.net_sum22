using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fundProject.Models;
namespace fundProject.Controllers
{
    public class User1RegistrationController : Controller
    {

        FundEntities dbobj = new FundEntities(); 

        [HttpGet]
        public ActionResult Registration()
        {
            users1 user1Model = new users1();

            return View();
        }
        [HttpPost]

        
        public ActionResult AddUsers(users1 userModel)
        {
            users1 obj = new users1();
            obj.uId = userModel.uId;    
            obj.uName = userModel.uName;    
            obj.uUserName = userModel.uUserName;    
            obj.uEmail = userModel.uEmail;  
            obj.uGender = userModel.uGender;    
            obj.uPassword = userModel.uPassword;

            dbobj.users1.Add(obj);
            dbobj.SaveChanges();

            return View("AddUsers");
            
        }
        

        
            

        }



    }
