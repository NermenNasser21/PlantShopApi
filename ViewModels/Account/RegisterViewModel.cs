using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required,StringLength(10,MinimumLength =3)]
        public string FirstName {  get; set; }

        [Required, StringLength(10, MinimumLength = 3)]
        public string LastName {  get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Email {  get; set; }

        [Required, StringLength(50, MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password {  get; set; }

        [Required, StringLength(50, MinimumLength = 10)]
        public string ConfirmPassword { get; set; }

    }
}
