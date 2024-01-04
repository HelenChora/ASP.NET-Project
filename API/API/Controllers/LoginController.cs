using API.AuthFilter;
using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            var token = AuthService.Authenticate(login.username, login.password);
            if (token != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Usernot found");

        }

        [Logged]
        [Route("api/logout")]
        [HttpPost]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization;
            var result = AuthService.logout(token.ToString());
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully logged out");
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unsuccessful logout");

        }

        [HttpGet]
        [Route("api/getUser")]
        public HttpResponseMessage getUserId()
        {
            int id = AuthService.userInfo(Request.Headers.Authorization.ToString());
            if (id > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unsuccessful");
        }
    }
}

