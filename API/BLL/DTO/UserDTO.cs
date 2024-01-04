using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
