using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class CustomerDetails
    {
        private static int s_customerID = 1000;
        public string CustomerID { get; }
        public string Name { get; set; }
        public string City { get; set; }
        public ulong MobileNumber { get; set; }
        public long WalletBalance { get; set; }
        public string EmailID { get; set; }

        public CustomerDetails(string name,string city,ulong mobileNumber,long walletBalance,string emailID)
        {
            s_customerID++;
            CustomerID = "CID"+s_customerID;
            Name = name;
            City = city;
            MobileNumber = mobileNumber;
            WalletBalance = walletBalance;
            EmailID = emailID;
        }
        public void WalletRecharge(long balance)
        {
            WalletBalance = WalletBalance+balance;
        }

    }
}