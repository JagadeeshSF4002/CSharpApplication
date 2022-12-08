using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class CustomerRegistration : PersonalDetails, IBalance
    {
        
        private static int s_customerID = 1000;
        public string CustomerID { get; set; }
        private long _balance; 
        public long WalletBalance {get {return _balance;}}

        public CustomerRegistration(string name, string fatherName, Gender gender, long mobileNumber, DateTime dob, string mailID,long balance) : base(name, fatherName, gender, mobileNumber, dob, mailID)
        {
            s_customerID++;
            CustomerID = "CID"+s_customerID;
            _balance = _balance+balance;
        }

        public CustomerRegistration(string data)
        {
            string[] values = data.Split(',');
            s_customerID = int.Parse(values[0].Remove(0,3));
            CustomerID = values[0];
            Name = values[1];
            FatherName = values[2];
            Gender = Enum.Parse<Gender>(values[3]);
            MobileNumber = long.Parse(values[4]);
            DOB = DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
            MailID = values[6];
            _balance = _balance + long.Parse(values[7]);
        }
        public void WalletRecharge(long amount)
        {
            _balance = _balance+amount;
        }

        public void DeductAmount(long amount)
        {
            _balance = _balance-amount;
        }
        public void ShowCustomerDetails()
        {
            System.Console.WriteLine($"Your ID : {CustomerID}");
            System.Console.WriteLine($"Your Name : {Name}");
            System.Console.WriteLine($"Father's Name : {FatherName}");
            System.Console.WriteLine($"Gender : {Gender}");
            System.Console.WriteLine($"Mobile NUmber : {MobileNumber}");
            System.Console.WriteLine($"Date Of Birth : {DOB.ToString("dd/MM/yyyy")}");
            System.Console.WriteLine($"Mail ID : {MailID}");
            System.Console.WriteLine($"Balance : {WalletBalance}");
        }
    }
}