using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerRepo : DatabaseRepo, ICrud<Customer, int, bool>
    {
        public bool Add(Customer data)
        {
            var user = new User();
            user.user_name = data.email;
            user.password = data.password;
            user.role = "Customer";
            database.Users.Add(user);
            database.SaveChanges();
            data.user_id = user.user_id;
            database.Customers.Add(data);
            return database.SaveChanges() > 0;
        }

        public bool Authenticate(string uname, string pass)
        {
            var data = database.Customers.FirstOrDefault(u => u.customer_name.Equals(uname) && u.password.Equals(pass));
            if (data != null)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            database.Customers.Remove(database.Customers.Find(id));
            return database.SaveChanges() > 0;
        }

        public Customer Get(int id)
        {
            return database.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return database.Customers.ToList();
        }

        public bool Update(Customer data)
        {
            var record = database.Customers.Find(data.customer_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }
    }
}
