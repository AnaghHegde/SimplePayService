using SimplePayService.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService.Data
{
    public class Storage
    {

        public static List<UserInfo> Users { get; set; }

        public static Dictionary<String, double> Merchants { get; set; }

        public static List<Transactions> Transactions { get; set; }

        public Storage()
        {
            Users = new List<UserInfo>();
            Merchants = new Dictionary<string, double>();
            Transactions = new List<Transactions>();
        }

    }
}
