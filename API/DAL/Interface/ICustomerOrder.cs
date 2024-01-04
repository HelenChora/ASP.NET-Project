using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICustomerOrder
    {
        List<Order> CustomerOrder(int id);
    }
}
