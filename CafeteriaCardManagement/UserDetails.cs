using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class UserDetails : PersonalDetails,IBalance
    {
        
        private static int s_userID = 1000;
        private long _balance;
        public string UserID { get; }
        public long WalletBalance { get{return _balance;}}
        public string WorkStationNumber { get; set; }
        
        public UserDetails(string name, string fatherName, Gender gender, long mobileNumber, string mailID,string workStationNumber,long balance) : base(name, fatherName, gender, mobileNumber, mailID)
        {
            s_userID++;
            UserID = "SF" + s_userID;
            WorkStationNumber = workStationNumber;
            _balance += balance;
        }

        public UserDetails(string data):base(data)
        {
            string[] values = data.Split(',');
            s_userID = int.Parse(values[0].Remove(0,2));
            UserID = values[0];
            WorkStationNumber = values[6];
            _balance = _balance + int.Parse(values[7]);
        }


        public void WalletRecharge(long amount)
        {
            _balance+=amount;
        }

        public void DeductAmount(long amount)
        {   
            _balance = _balance - amount;
        }

     
    }
}