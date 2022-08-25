using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.BOs;
using BLL.Services;
using System.Web.Http.Cors;

namespace PL.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RaiserController : ApiController
    {
        [Route("api/raiser/")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = RaiserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/raiser/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = RaiserService.GetOnly(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/raiser/create")]
        [HttpPost]
        public HttpResponseMessage Create(RaiserModel st)
        {
            var data = RaiserService.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/raiser/update")]
        [HttpPost]
        public HttpResponseMessage Update(RaiserModel user)
        {
            var data = RaiserService.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/raiser/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {


            var data1 = RaiserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data1);
        }
    }
}
