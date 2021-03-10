using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService.Data
{
    public class UserInfo
    {
        public String UserName { get; set; }

        public String Email { get; set; }

        public int CreditLimit { get; set; }

        public int Dues { get; set; }
    }
}
