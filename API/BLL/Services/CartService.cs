using AutoMapper;
using BLL.DTO;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartService
    {
        public static List<CartDTO> GetCarts()
        {
            var data = DataAccessFactory.CartDataAccess().GetAll();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Cart, CartDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CartDTO>>(data);
        }
        public static CartDTO GetCart(int id)
        {
            var data = DataAccessFactory.CartDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Cart, CartDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CartDTO>(data);
        }
        public static bool DeleteCart(int id)
        {
            return DataAccessFactory.CartDataAccess().Delete(id);
        }
        public static bool AddCart(CartDTO Data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CartDTO, Cart>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Cart>(Data);
            return DataAccessFactory.CartDataAccess().Add(value);
        }
        public static bool CartUpdate(CartDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CartDTO, Cart>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Cart>(data);
            return DataAccessFactory.CartDataAccess().Update(value);
        }

    }
}
