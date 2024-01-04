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
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("api/Add/Order")]
        public HttpResponseMessage AddOrder(OrderDTO data)
        {
            try
            {
                var user = OrderService.AddOrder(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Order/Delete/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            try
            {
                var data = OrderService.DeleteOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Order/Update")]
        public HttpResponseMessage UpdateOrder(OrderDTO data)
        {
            try
            {
                var user = OrderService.OrderUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Orders")]
        public HttpResponseMessage GetOrders()
        {
            try
            {
                var data = OrderService.GetOrders();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Order/{id}")]
        public HttpResponseMessage GetOrder(int id)
        {
            try
            {
                var data = OrderService.GetOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Customer/Orders/{id}")]
        public HttpResponseMessage CustomerOrder(int id)
        {
            try
            {
                var data = OrderService.CustomerOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}

