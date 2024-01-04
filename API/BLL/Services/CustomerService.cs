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
    public class CustomerService
    {
        public static List<CustomerDTO> GetCustomers()
        {
            var data = DataAccessFactory.CustomerDataAccess().GetAll();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<CustomerDTO>>(data);
        }
        public static CustomerDTO GetCustomer(int id)
        {
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<CustomerDTO>(data);
        }
        public static bool DeleteCustomer(int id)
        {
            return DataAccessFactory.CustomerDataAccess().Delete(id);
        }
        public static bool AddCustomer(CustomerDTO Data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Customer>(Data);
            return DataAccessFactory.CustomerDataAccess().Add(value);
        }
        public static bool CustomerUpdate(CustomerDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<Customer>(data);
            return DataAccessFactory.CustomerDataAccess().Update(value);
        }
    }
}
