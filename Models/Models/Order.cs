using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Enums;


namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public PaymentWays PaymentWay { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string? Picture { get; set; }
        public string City { get; set; }
        public string? Note { get; set; }
        public decimal OrderPrice { get; set; }
        public string UserId { get; set; }
        public virtual User User {  get; set; }
        public virtual ICollection<OrderedProduct> Products {  get; set; }


    }
}
