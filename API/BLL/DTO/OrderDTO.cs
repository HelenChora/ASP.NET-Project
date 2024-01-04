﻿using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderDTO
    {
      
        public int customer_id { get; set; }
        public int book_id { get; set; }
        public int total_price { get; set; }
        public int status { get; set; }
    }
}