using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : DatabaseRepo, ICrud<User, int, bool>, IAuth
    {

        public bool Add(User data)
        {
            database.Users.Add(data);
            return database.SaveChanges() > 0;
        }

        public User Authenticate(string uname, string pass)
        {
            var data = database.Users.FirstOrDefault(u => u.user_name.Equals(uname) && u.password.Equals(pass));
            if (data != null)
            {
                return data;
            }
            return null;
        }


        public bool Delete(int id)
        {
            database.Users.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return database.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return database.Users.ToList();
        }

        public bool Update(User data)
        {
            var record = Get(data.user_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
