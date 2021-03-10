using SimplePayService.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService
{
    public interface IOnboardService
    {
        public void AddUser(UserInfo user);

        public void AddMerchant(String name, double discount);
    }
}
