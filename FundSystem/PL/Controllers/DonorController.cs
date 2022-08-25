using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.BOs;
using BLL.Services;
using System.Web.Http.Cors;

using PL.Auth;

namespace PL.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DonorController : ApiController
    {
       
        [ValidUser]
        [Route("api/donor/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = DonorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/donor/{id}")] 
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = DonorService.GetOnly(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/donor/create")]
        [HttpPost]
        public HttpResponseMessage Create(DonorModel st)
        {
            var data = DonorService.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/donor/update")]
        [HttpPost]
        public HttpResponseMessage Update(DonorModel user)
        {
            var data = DonorService.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/donor/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {


            var data1 = DonorService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data1);
        }
    }
}
