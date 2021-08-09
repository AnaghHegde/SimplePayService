using SimplePayService.Data;
using SimplePayService.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService
{
    public class TransactionService : ITransactionService
    {
        public int buyItems(string userName, string merchantName, int amount)
        {
            double discount = GetMerchantDiscount(merchantName);
            double finalPrice = GetValueAfterDscount(discount, amount);
            int avaialbleCredit = GetUserCredit(userName);
            if(amount <= avaialbleCredit)
            {
                Transactions transaction = new Transactions
                {
                    UserName = userName,
                    MerchantName = merchantName,
                    Discount = amount-finalPrice,
                    Cost = amount
                };
                Storage.Transactions.Add(transaction);
                UpdateCredit(userName, amount);
                return 1;
            }

            return -1;
        }



//Adding comment
        public int payDue(string userName, int due)
        {
            return UpdateCredit(userName, due *-1);
        }

        private int UpdateCredit(String user, int credit)
        {
            foreach (UserInfo user1 in Storage.Users)
            {
                if (user1.UserName.Equals(user))
                {
                    user1.Dues = user1.Dues + credit;
                    return user1.Dues;
                }
            }
            return -1;
        }

        private int GetUserCredit(String user)
        {
            var users = Storage.Users;
            foreach(UserInfo user1 in users)
            {
                if(user1.UserName.Equals(user))
                {
                    return user1.CreditLimit - user1.Dues;
                }
            }

            return -1;
        }

        private double GetValueAfterDscount(double discount, int price)
        {
            return price - (price * (discount / 100));
        }

        private double GetMerchantDiscount(String merchant)
        {
            if (Storage.Merchants.ContainsKey(merchant))
            {
                return Storage.Merchants[merchant];
            }
            return -1;
        }

    }
}
