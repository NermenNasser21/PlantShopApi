using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public static class OrderExtensions
    {
        public static Order ToModel(this AddOrderViewModel model)
        {

            
            if (model.Picture != null) 
            {
                string fileName = DateTime.Now.ToFileTime().ToString() + model.Picture.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Orders", fileName);
                FileStream stream = new(path, FileMode.Create);
                model.Picture.CopyTo(stream);
                stream.Close();
                var ImagePath = (Path.Combine("Images", "Orders", fileName));
               

                return new Order
                {
                    Time = DateTime.UtcNow,
                    Picture = ImagePath,
                    OrderPrice = model.OrderPrice,
                    PaymentWay = model.PaymentWay,
                    status = Enums.orderStatus.Pending,
                    DeliveryPrice = model.DeliveryPrice,
                    City = model.City,
                    Note= model.Note,

                    
                    
                    
                    

                };
            }
            return new Order
            {
                Time = DateTime.UtcNow,
                OrderPrice = model.OrderPrice,
                PaymentWay = model.PaymentWay,
                status = Enums.orderStatus.Pending,
                DeliveryPrice = model.DeliveryPrice,
                City = model.City,
                Note = model.Note,


            };

        }
    }
}
