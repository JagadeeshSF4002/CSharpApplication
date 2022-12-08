using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountApplication
{
    public enum Gender
    {
        Default,Male,Female,Transgender
    }
    public enum AccountType
    {
        Default,SA,CA,RD,FD
    }
    public class CustomerDetails
    {
        private static long s_accountNumber = 10000;

        private static long s_Balance;
        public long AccountNumber { get;}
        public string CustomerName { get; set; }
        public Gender Gender { get; set; }
        public AccountType AccountType { get; set; }

        public long Balance { get{return s_Balance;} }
        public DateTime DOB{get;set;}
        public string MailID { get; set; }
        public string Address { get; set; }

        public CustomerDetails(string customerName,Gender gender,AccountType accountType,long balance,DateTime dob,string mailID,string address)
        {
            s_accountNumber++;
            AccountNumber = s_accountNumber;
            CustomerName = customerName;
            Gender = gender;
            AccountType = accountType;
            s_Balance = s_Balance+balance;
            DOB = dob;
            MailID = mailID;
            Address = address;
        }

        public void Withdraw(long amount)
        {
            s_Balance = s_Balance - amount;
            
        }

        public void Deposit(long amount)
        {
            s_Balance = s_Balance + amount;
            
        }

        
    }
}