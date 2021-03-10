using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService
{
    public class Transaction
    {
        public String UserName { get; set; }

        public String Merchant { get; set; }

        public int Cost { get; set; }

        public int Discount { get; set; }
    }
}
