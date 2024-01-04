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
    public class OrderService
    {
        public static List<OrderDTO> GetOrders()
        {
            var data = DataAccessFactory.OrderDataAccess().GetAll();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }
        public static OrderDTO GetOrder(int id)
        {
            var data = DataAccessFactory.OrderDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<OrderDTO>(data);
        }
        public static bool DeleteOrder(int id)
        {
            return DataAccessFactory.OrderDataAccess().Delete(id);
        }
        public static bool AddOrder(OrderDTO Data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Order>(Data);
            return DataAccessFactory.OrderDataAccess().Add(value);
        }
        public static bool OrderUpdate(OrderDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<OrderDTO, Order>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Order>(data);
            return DataAccessFactory.OrderDataAccess().Update(value);
        }
        public static List<OrderDTO> CustomerOrder(int id)
        {
            var data = DataAccessFactory.CustomerOrderAccess().CustomerOrder(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<OrderDTO>>(data);
        }
    }
}
