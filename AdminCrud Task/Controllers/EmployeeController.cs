using CRUD.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: employee
        CrudEntities dbObj = new CrudEntities(); 
        public ActionResult Employee(employee obj)
        {   
            /*
            if(obj!=null) 
                
               return View(obj);
            else
            */
            return View(obj);  
        }
        [HttpPost]
        public ActionResult AddStudent(employee model)
        {
            employee obj = new employee();

            if (ModelState.IsValid)
            {
              
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.FName = model.FName;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;

                if(model.Id == 0)
                {
                    dbObj.Students.Add(obj);
                    dbObj.SaveChanges();

                }

                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }

            }
            ModelState.Clear();

            return View("Student");
        }

        public ActionResult StudentList()
        {
            var list = dbObj.Students.ToList(); 
            return View(list);
        }

        public ActionResult Delete(int id)
        {
            var list = dbObj.Students.Where(x => x.Id == id).First();
            dbObj.Students.Remove(list);
            dbObj.SaveChanges();

            var newList = dbObj.Students.ToList();

            return View("StudentList",newList);
        }


    }
}