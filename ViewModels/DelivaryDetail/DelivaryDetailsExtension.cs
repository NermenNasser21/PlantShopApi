using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class DelivaryDetailsExtension
    {
        public static DelivaryDetails ToModel(this AddDelivaryDetailModeL model)
        {

        
            return new DelivaryDetails
            {
                Price = model.Price,
               City=model.City
            };

        }
    }
}
