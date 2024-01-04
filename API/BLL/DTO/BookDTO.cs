using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookDTO
    {
        public int book_id { get; set; }
        [Required(ErrorMessage = "Book name is required")]
        [StringLength(100, ErrorMessage = "Book name must be at most 100 characters")]
        public string book_name { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative value")]
        public int stock { get; set; }
        [Required(ErrorMessage = "Unit price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Unit price must be a non-negative value")]
        public int unit_price { get; set; }
        public DateTime store_date { get; set; }
        public DateTime stockout_date { get; set; }

    }
}
