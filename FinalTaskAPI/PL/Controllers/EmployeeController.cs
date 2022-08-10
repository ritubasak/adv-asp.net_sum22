using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.BOs;
using BLL.Services;

namespace PL.Controllers
{
    public class EmployeeController : ApiController
    {
        [Route("api/employee/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = EmpService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/employee/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = EmpService.GetOnly(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/employee/create")]
        [HttpPost]
        public HttpResponseMessage Create(EmpModel st)
        {
            var data = EmpService.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/employee/update")]
        [HttpPost]
        public HttpResponseMessage Update(EmpModel user)
        {
            var data = EmpService.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/employee/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {


            var data1 = EmpService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data1);
        }
    }
}
