using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Enums;

namespace ViewModels
{
    public class AddOrderViewModel
    {
        public PaymentWays PaymentWay { get; set; }
        public decimal DeliveryPrice { get; set; }
        public IFormFile? Picture { get; set; }
        public string City { get; set; }
        public string? Note { get; set; }
        public decimal OrderPrice { get; set; }
        public string? UserId { get; set; }
        public int? CartId {  get; set; }
        

        
    }
}
