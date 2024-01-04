using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class DataAccessFactory
    {



        public static ICrud<Customer, int, bool> CustomerDataAccess()
        {
            return new CustomerRepo();
        }

        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }

        public static ICrud<User, int, bool> UserDataAccess()
        {
            return new UserRepo();
        }

        public static ICrud<Book, int, bool> BookDataAccess()
        {
            return new BookRepo();
        }

        public static ICrud<Order, int, bool> OrderDataAccess()
        {
            return new OrderRepo();
        }

        public static ICrud<Cart, int, bool> CartDataAccess()
        {
            return new CartRepo();
        }

        public static ICustomerOrder CustomerOrderAccess()
        {
            return new OrderRepo();
        }

    

        public static ICustomerCart OrderCartAccess()
        {
            return new CartRepo();
        }
        public static ICrud<Token, int, bool> TokenDataAccess()
        {
            return new TokenRepo();
        }
    }
}
