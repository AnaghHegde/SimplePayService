using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService
{
    public interface ITransactionService
    {
        public int payDue(String userName, int due);

        int buyItems(String userName, String merchantName, int amount);
    }
}
