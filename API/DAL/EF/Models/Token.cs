using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Token
    {
        [Key]
        public int token_id { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }
        public string token_key { get; set; }
        public DateTime created { get; set; }
        public DateTime? expired { get; set; }

        public virtual User User { get; set; }
    }
}
