using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace shop.ViewModel
{
    public class LoginSellerViewModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email is required")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
