using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Enums;

namespace ViewModels
{
    public class OrderViewModel
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Time { get; set; }
        public decimal TotalPrice {  get; set; }
        public string? Note { get; set; }
        public PaymentWays PaymentWay { get; set; }
        public orderStatus status { get; set; }
        public string? Picture { get; set; }

        public ICollection<OrderedProduct> Products {  get; set; }


    }
}
