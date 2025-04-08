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
        public PaymentWays Name { get; set; }

    }
}
