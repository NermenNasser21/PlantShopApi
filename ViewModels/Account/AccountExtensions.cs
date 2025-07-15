using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class AccountExtensions
    {
        public static User ToModel(this RegisterViewModel model)
        {
            return new User
            {
                UserName = model.Email,
                Name = $"{model.FirstName}{model.LastName}",
                Email = model.Email
                

            };
        }

       
    }
}
