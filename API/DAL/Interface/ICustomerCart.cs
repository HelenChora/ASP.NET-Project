﻿using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ICustomerCart
    {
        List<Cart> CustomerCart(int id);
    }
}
