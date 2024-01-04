using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TokenDTO
    {
        public int token_id { get; set; }
        public int user_id { get; set; }
        public string token_key { get; set; }
        public DateTime created { get; set; }
        public DateTime? expired { get; set; }
    }
}
