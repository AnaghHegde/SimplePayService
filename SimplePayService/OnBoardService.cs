using SimplePayService.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService
{
    public class OnBoardService : IOnboardService
    {
        public void AddMerchant(string name, double discount)
        {
            if (Storage.Merchants.ContainsKey(name))
            {
                Storage.Merchants[name] = discount;
                Console.WriteLine("Merchant discount updated \n");
            }
            else
            {
                Storage.Merchants[name] = discount;
                Console.WriteLine("Merchant Created \n");
            }
        }

        public void AddUser(UserInfo user)
        {
            UserInfo user1 = new UserInfo
            {
                UserName = user.UserName,
                CreditLimit = user.CreditLimit,
                Dues = user.Dues,
                Email = user.Email
            };
            Storage.Users.Add(user1);
            Console.WriteLine("User Created \n");
        }
    }
}
