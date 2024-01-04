using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CartRepo : DatabaseRepo, ICrud<Cart, int, bool>, ICustomerCart
    {
        public bool Add(Cart data)
        {
            database.Carts.Add(data);
            return database.SaveChanges() > 0;
        }

        public List<Cart> CustomerCart(int id)
        {
            var data = new List<Cart>();
            foreach (var Cart in database.Carts)
            {
                if (Cart.customer_id == id)
                {
                    data.Add(Cart);
                }
            }
            return data;
        }

        public bool Delete(int id)
        {
            database.Carts.Remove(Get(id));
            return database.SaveChanges() > 0;
        }

        public Cart Get(int id)
        {
            return database.Carts.Find(id);
        }

        public List<Cart> GetAll()
        {
            return database.Carts.ToList();
        }

        public bool Update(Cart data)
        {
            var record = Get(data.cart_id);
            database.Entry(record).CurrentValues.SetValues(data);
            return database.SaveChanges() > 0;
        }


    }
}
