using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;
using BLL.BOs;
using BLL.Services;
using System.Web.Http.Cors;

namespace PL.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        
        public HttpResponseMessage Login(DonorModel obj)
        {
            var data = AuthService.Authenticate(obj.dnUserName, obj.dnPassword);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        [Route("api/logout")]
        //[HttpGet]
        public HttpResponseMessage Logout(TokenModel obj)
        {
            var data = AuthService.Logout(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
