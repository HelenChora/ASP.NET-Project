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
    public class CartController : ApiController
    {
        [HttpPost]
        [Route("api/Add/Cart")]
        public HttpResponseMessage AddCart(CartDTO data)
        {
            try
            {
                var user = CartService.AddCart(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Cart/Delete/{id}")]
        public HttpResponseMessage DeleteCart(int id)
        {
            try
            {
                var data = CartService.DeleteCart(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpPost]
        [Route("api/Cart/Update")]
        public HttpResponseMessage UpdateCart(CartDTO data)
        {
            try
            {
                var user = CartService.CartUpdate(data);
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Carts")]
        public HttpResponseMessage GetCarts()
        {
            try
            {
                var data = CartService.GetCarts();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/View/Cart/{id}")]
        public HttpResponseMessage GetCart(int id)
        {
            try
            {
                var data = CartService.GetCart(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /*   [HttpGet]
           [Route("api/new/order")]
           public HttpResponseMessage NewOrder()
           {
               try
               {
                   var data = CartService.OrderCartUpdate();
                   return Request.CreateResponse(HttpStatusCode.OK, data);
               }
               catch (Exception ex)
               {
                   return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
               }
           }
       }*/
    }
}

