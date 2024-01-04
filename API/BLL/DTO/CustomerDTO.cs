using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CustomerDTO
    {
        public int customer_id { get; set; }
        //[Required(ErrorMessage = "You must enter your name!")]
        //[RegularExpression("^[A-Za-z][A-Za-z_. ,]{2,49}$", ErrorMessage = "Please enter a valid name!")]
        public string customer_name { get; set; }
        public string email { get; set; }
        //[RegularExpression(".*(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$ %^&*~><.,:;]).*", ErrorMessage = "Password format is incorrect!")]
        public string password { get; set; }
        public string contact { get; set; }
        public string location { get; set; }
        public int user_id { get; set; }
    }
}
