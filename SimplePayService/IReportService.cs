using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePayService
{
    public interface IReportService
    {
        double GetMerchantDiscount(String merchantName);

        int GetDues(String userName);

        List<String> GetCreditLimitUsers();

        int TotalDues();
        
    }
}
