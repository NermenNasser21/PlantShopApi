using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Account
{
    public static class AccountExtensions
    {
        public static User ToModel(this RegisterViewModel model)
        {
            return new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = $"{model.FirstName} {model.LastName}",
                Email = model.Email
                

            };
        }

       
    }
}
