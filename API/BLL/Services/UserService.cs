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
    public class UserService
    {
        public static List<UserDTO> GetUsers()
        {
            var data = DataAccessFactory.UserDataAccess().GetAll();
            var config = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);
        }
        public static UserDTO GetUser(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<UserDTO>(data);
        }
        public static bool DeleteUser(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }
        public static bool AddUser(UserDTO Data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<User>(Data);
            return DataAccessFactory.UserDataAccess().Add(value);
        }
        public static bool UserUpdate(UserDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var value = mapper.Map<User>(data);
            return DataAccessFactory.UserDataAccess().Update(value);
        }

    }
}
