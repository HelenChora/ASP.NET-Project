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
    public class CustomerController : ApiController
    {
        [HttpPost]
        [Route("api/Add/Customer")]
        public HttpResponseMessage AddCustomer(CustomerDTO data)
        {
            try
            {
                var user = CustomerService.AddCustomer(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Customer/Delete/{id}")]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            try
            {
                var data = CustomerService.DeleteCustomer(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Customer/Update")]
        public HttpResponseMessage UpdateCustomer(CustomerDTO data)
        {
            try
            {
                var user = CustomerService.CustomerUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Customers")]
        public HttpResponseMessage GetCustomers()
        {
            try
            {
                var data = CustomerService.GetCustomers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Customer/{id}")]
        public HttpResponseMessage GetCustomer(int id)
        {
            try
            {
                var data = CustomerService.GetCustomer(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}

