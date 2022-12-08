using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public class UserDetails:PersonalDetails,IWallet
    {
        private static int s_userID = 1000;
        private double _balance;
        

        public string UserID { get;}
        public double WalletBalance { get{return _balance;}  }
        
        
        public UserDetails(string name, int age, ulong phoneNumber,int balance) : base(name, age, phoneNumber)
        {
            s_userID++;
            UserID = "UID"+s_userID;
            _balance = _balance + balance;
        }

        public UserDetails(string data):base(data)
        {
            string[] values = data.Split(',');
            s_userID = int.Parse(values[0].Remove(0,3));
            UserID = values[0];
            Name = values[1];
            Age = int.Parse(values[2]);
            PhoneNumber = ulong.Parse(values[3]);
            _balance = _balance + double.Parse(values[4]);
        }

        public double RechargeWallet(double amount)
        {
            _balance = _balance + amount;
            return _balance;
        }

        public double DeductBalance(double amount)
        {
            _balance = _balance - amount;
            return _balance;
        }


    }
}