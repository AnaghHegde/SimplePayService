using Microsoft.Extensions.DependencyInjection;
using SimplePayService.Data;
using System;

namespace SimplePayService
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IOnboardService, OnBoardService>()
                .AddSingleton<ITransactionService, TransactionService>()
                .AddSingleton<IReportService, ReportService>()
                .BuildServiceProvider();
            var reportService = serviceProvider.GetService<IReportService>();
            var transactionService = serviceProvider.GetService<ITransactionService>();
            var onboardService = serviceProvider.GetService<IOnboardService>();
            Storage storage = new Storage();
            
            while (true)
            {
                String val = Console.ReadLine();
                var parameters = val.Split(" ");
                switch (parameters[0])
                {

                    case "new":
                        {
                            if (parameters[1].Equals("user"))
                            {
                                UserInfo userInfo = new UserInfo();
                                userInfo.CreditLimit = Int32.Parse(parameters[4]);
                                userInfo.Dues = 0;
                                userInfo.Email = parameters[3];
                                userInfo.UserName = parameters[2];
                                onboardService.AddUser(userInfo);
                            }

                            if (parameters[1].Equals("merchant"))
                            {
                                onboardService.AddMerchant(parameters[2], Convert.ToDouble(parameters[4].Remove(parameters[4].Length -1)));
                            }

                            if (parameters[1].Equals("txn"))
                            {
                                if(transactionService.buyItems(parameters[2], parameters[3], Int32.Parse(parameters[4])) == -1)
                                {
                                    Console.WriteLine("rejected! (reason: credit limit)\n");
                                } else
                                {
                                    Console.WriteLine("Success!\n");
                                }
                            }

                        }
                        break;

                    case "report":
                        {
                            if (parameters[1].Equals("total-dues"))
                            {
                                Console.WriteLine("Total Dues : "+ reportService.TotalDues()+"\n"); ;
                            }

                            if (parameters[1].Equals("users-at-credit-limit"))
                            {
                                var userList = reportService.GetCreditLimitUsers();
                                foreach(String user in userList)
                                {
                                    Console.WriteLine(user+"\n");
                                }
                            }

                            if (parameters[1].Equals("dues"))
                            {
                                Console.WriteLine(reportService.GetDues(parameters[2])+"\n");
                            }
                            if (parameters[1].Equals("discount"))
                            {
                                Console.WriteLine(reportService.GetMerchantDiscount(parameters[2])+"\n");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "update":
                        {
                            if (parameters[1].Equals("merchant"))
                            {
                                onboardService.AddMerchant(parameters[2], Convert.ToDouble(parameters[3].Remove(parameters[3].Length - 1)) );
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "payback":
                        {
                            int dues = transactionService.payDue(parameters[1], Int32.Parse(parameters[2]));
                            dues = dues < 0 ? 0 : dues;
                            Console.WriteLine( "Dues : " + dues +"\n");
                        }
                        break;
                }
            }
            
        }
    }
}
