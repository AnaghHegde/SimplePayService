using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService.Data.Contracts
{
    public class Transactions
    {
        public String MerchantName { get; set; }

        public string UserName { get; set; }

        public int Cost { get; set; }

        public double Discount { get; set; }

    }
}
