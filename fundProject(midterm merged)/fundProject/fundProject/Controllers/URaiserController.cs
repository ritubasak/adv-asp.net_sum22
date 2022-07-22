using fundProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fundProject.Controllers
{
    public class URaiserController : Controller
    {
        // GET: Raiser
        FundEntities dbobj2 = new FundEntities();
        
        [HttpGet]
        public ActionResult RaiserRegistration()
        {
            return View(); 
        }
        [HttpPost]  
        public ActionResult AddRaisers(raiser userModel)
        {
            raiser obj2 = new raiser(); 
            obj2.uName = userModel.uName;   
            obj2.uraiseAmount = userModel.uraiseAmount; 
            obj2.uDescription = userModel.uDescription; 
            obj2.uAddress = userModel.uAddress; 
            obj2.uEmail = userModel.uEmail; 
            obj2.uMobile = userModel.uMobile;   
            obj2.Date = userModel.Date;
            obj2.image = userModel.image;
            
            dbobj2.raisers.Add(obj2);   
             
            dbobj2.SaveChanges();
            
            return View("AddRaisers");

        }


    }
}