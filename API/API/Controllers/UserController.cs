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
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/Add/User")]
        public HttpResponseMessage AddUser(UserDTO data)
        {
            try
            {
                var user = UserService.AddUser(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/User/Delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                var data = UserService.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/User/Update")]
        public HttpResponseMessage UpdateUser(UserDTO data)
        {
            try
            {
                var user = UserService.UserUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Users")]
        public HttpResponseMessage GetUsers()
        {
            try
            {
                var data = UserService.GetUsers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/User/{id}")]
        public HttpResponseMessage GetUser(int id)
        {
            try
            {
                var data = UserService.GetUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}

