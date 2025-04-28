using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Account
{
    public class LoginViewModel
    {
        [Required, StringLength(50, MinimumLength = 10)]
        public string Email {  get; set; }

        [Required, StringLength(50, MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;

        
    }
}
