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
    public class BookController : ApiController
    {
        [HttpPost]
        [Route("api/Add/Book")]
        public HttpResponseMessage AddItem(BookDTO data)
        {
            try
            {
                var user = BookService.AddItem(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/Book/Delete/{id}")]
        public HttpResponseMessage DeleteItem(int id)
        {
            try
            {
                var data = BookService.DeleteItem(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Book/Update")]
        public HttpResponseMessage UpdateItem(BookDTO data)
        {
            try
            {
                var user = BookService.ItemUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Books")]
        public HttpResponseMessage GetItems()
        {
            try
            {
                var data = BookService.GetItems();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Book/{id}")]
        public HttpResponseMessage GetItem(int id)
        {
            try
            {
                var data = BookService.GetItem(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}

