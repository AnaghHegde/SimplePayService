using SimplePayService.Data;
using SimplePayService.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService
{
    public class ReportService : IReportService
    {
        public List<string> GetCreditLimitUsers()
        {
            List<string> users = new List<string>();
            foreach (UserInfo user1 in Storage.Users)
            {
                if (user1.Dues == user1.CreditLimit)
                {
                    users.Add(user1.UserName);
                }
            }
            return users;
        }

        public int GetDues(string userName)
        {
            foreach (UserInfo user1 in Storage.Users)
            {
                if (user1.UserName.Equals(userName))
                {
                    return user1.Dues;
                }
            }
            return 1;
        }

        public double GetMerchantDiscount(string merchantName)
        {
            double merchantDiscount = 0;
            foreach (Transactions transactions in Storage.Transactions)
            {
                if (transactions.MerchantName.Equals(merchantName))
                {
                    merchantDiscount += transactions.Discount;
                }
            }
            return merchantDiscount;
        }

        public int TotalDues()
        {
            int dues = 0;
            foreach (UserInfo user1 in Storage.Users)
            {
                dues += user1.Dues;
                Console.WriteLine(user1.UserName+" : "+ user1.Dues+"\n");
            }
            return dues;
        }
    }
}
