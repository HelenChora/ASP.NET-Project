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
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string pass)
        {
            var rs = DataAccessFactory.AuthDataAccess().Authenticate(uname, pass);
            if (rs != null)
            {

                var tk = new Token();
                tk.user_id = rs.user_id;
                tk.created = DateTime.Now;
                tk.expired = null;
                tk.token_key = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TokenDataAccess().Add(tk);
                if (rt)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<TokenDTO>(tk);
                    return data;
                }
            }
            return null;
        }

        public static bool IsTokenValid(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().GetAll();
            var data = tk.FirstOrDefault(u => u.token_key.Equals(token));
            if (data != null && data.expired == null)
            {
                return true;
            }
            return false;

        }

        public static bool logout(string token)
        {
            var tk = DataAccessFactory.TokenDataAccess().GetAll();
            var data = tk.FirstOrDefault(u => u.token_key.Equals(token));
            if (data != null && data.expired == null)
            {
                data.expired = DateTime.Now;
                return DataAccessFactory.TokenDataAccess().Update(data);
            }
            return false;
        }

        public static int userInfo(string token)
        {
            var tokens = DataAccessFactory.TokenDataAccess().GetAll();
            var customers = DataAccessFactory.CustomerDataAccess().GetAll();
            var data = tokens.FirstOrDefault(u => u.token_key.Equals(token));
            var record = customers.FirstOrDefault(u => u.user_id.Equals(data.user_id));
            if (data != null && data.expired == null)
            {
                return record.customer_id;
            }
            return 0;
        }

    }
}
