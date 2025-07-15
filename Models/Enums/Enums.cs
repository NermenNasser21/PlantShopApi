using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Enums
    {
        public enum PaymentWays
        {
            Cash,
            Wallet
        }

        public enum orderStatus
        {
            Pending,
            Delivering,
            Canceled,
            Completed
        }
    }
}
