using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails
    {
        private static int s_cardNumbers = 100;
        private long _balance;
        public string CardNumber { get; set; }
        public string UserName { get; set; }
        public ulong MobileNumber { get; set; }
        public long Balance { get{return _balance;} }

        public UserDetails(string userName,ulong mobileNumber,long balance)
        {
            s_cardNumbers++;
            CardNumber = "CMRL"+s_cardNumbers;
            UserName = userName;
            MobileNumber = mobileNumber;
            _balance = _balance + balance;
        }

        public UserDetails(string data)
        {
            string[] values = data.Split(',');
            s_cardNumbers = int.Parse(values[0].Remove(0,4));
            CardNumber = values[0];
            UserName = values[1];
            MobileNumber = ulong.Parse(values[2]);
            _balance = _balance + long.Parse(values[3]);
        }

        public void Recharge(long amount)
        {
            _balance = _balance + amount;
        }

        public void DeductAmount(long amount)
        {
            _balance = _balance - amount;
        }
    }
}